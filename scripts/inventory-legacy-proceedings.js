// Executar com mongosh apontando para o banco de procedimentos. Somente leitura.
// MAPPING_FILE e opcional; o arquivo deve conter [{"id":"...","tenantId":"..."}].
const fs = require('fs');
const collection = db.getCollection('proceedings');
const mappingFile = process.env.MAPPING_FILE;
let assignments = [];

if (mappingFile) {
  assignments = JSON.parse(fs.readFileSync(mappingFile, 'utf8'));
  if (!Array.isArray(assignments)) throw new Error('O mapeamento deve ser uma lista JSON.');
}

const mapping = new Map();
for (const item of assignments) {
  if (!item || typeof item.id !== 'string' || !/^[a-fA-F0-9]{24}$/.test(item.id) ||
      typeof item.tenantId !== 'string' || !item.tenantId.trim() || item.tenantId !== item.tenantId.trim()) {
    throw new Error('Cada entrada deve conter um ObjectId valido e um tenantId nao vazio, sem espacos nas extremidades.');
  }
  const id = item.id.toLowerCase();
  if (mapping.has(id)) throw new Error(`Identificador duplicado no mapeamento: ${id}`);
  mapping.set(id, item.tenantId);
}

const legacyFilter = { $or: [
  { tenantId: { $exists: false } },
  { tenantId: null },
  { tenantId: { $type: 'string', $regex: '^\\s*$' } },
  { $expr: { $ne: [{ $type: '$tenantId' }, 'string'] } }
] };
const records = collection.find(legacyFilter, { _id: 1, name: 1, code: 1, tenantId: 1 }).toArray();
const legacyIds = new Set(records.map(record => record._id.toString().toLowerCase()));
const unrecognized = [...mapping.keys()].filter(id => !legacyIds.has(id));
if (unrecognized.length) throw new Error(`Mapeamento contem IDs inexistentes ou nao legados: ${unrecognized.join(', ')}`);

const report = {
  database: db.getName(),
  generatedAt: new Date().toISOString(),
  mode: 'read-only',
  tenantIdsRequireIndependentVerification: true,
  totalLegacy: records.length,
  mapped: records.filter(record => mapping.has(record._id.toString().toLowerCase())).length,
  records: records.map(record => ({
    id: record._id.toString(),
    name: record.name ?? null,
    code: record.code ?? null,
    currentTenantId: record.tenantId ?? null,
    proposedTenantId: mapping.get(record._id.toString().toLowerCase()) ?? null
  }))
};
report.unmapped = report.totalLegacy - report.mapped;
print(JSON.stringify(report, null, 2));
