using MongoDB.Driver;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;
using Vyracare.Api.Proceedings.Features.Proceedings.Shared.Ports;
using Vyracare.Api.Proceedings.Infrastructure.Persistence.Documents;

namespace Vyracare.Api.Proceedings.Infrastructure.Persistence;

/// <summary>
/// Implementa a integra??o com a persist?ncia ou com uma depend?ncia externa da aplica??o.
/// </summary>
public sealed class MongoProceedingRepository : IProceedingRepository
{
    private readonly IMongoCollection<ProceedingDocument> _collection;

/// <summary>
/// Inicializa uma nova inst?ncia de MongoProceedingRepository.
/// </summary>
    public MongoProceedingRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<ProceedingDocument>("proceedings");
    }

/// <summary>
/// Recupera a cole??o de registros dispon?veis para esta feature.
/// </summary>
    public async Task<IReadOnlyCollection<Proceeding>> ListAsync()
    {
        var documents = await _collection.Find(Builders<ProceedingDocument>.Filter.Empty).ToListAsync();
        return documents.Select(MapToDomain).ToArray();
    }

/// <summary>
/// Recupera um registro espec?fico a partir do seu identificador.
/// </summary>
    public async Task<Proceeding?> GetByIdAsync(string id)
    {
        var document = await _collection.Find(item => item.Id == id).FirstOrDefaultAsync();
        return document is null ? null : MapToDomain(document);
    }

/// <summary>
/// Persiste um novo registro e devolve a entidade resultante da opera??o.
/// </summary>
    public async Task<Proceeding> AddAsync(Proceeding proceeding)
    {
        var document = MapToDocument(proceeding);
        await _collection.InsertOneAsync(document);
        proceeding.Id = document.Id;
        return proceeding;
    }

    private static ProceedingDocument MapToDocument(Proceeding proceeding) => new()
    {
        Id = proceeding.Id,
        Name = proceeding.Name,
        Category = proceeding.Category,
        Code = proceeding.Code,
        TargetArea = proceeding.TargetArea,
        DurationMinutes = proceeding.DurationMinutes,
        SessionPrice = proceeding.SessionPrice,
        SessionCount = proceeding.SessionCount,
        RecoveryTime = proceeding.RecoveryTime,
        Description = proceeding.Description,
        Active = proceeding.Active,
        CreatedAt = proceeding.CreatedAt,
        UpdatedAt = proceeding.UpdatedAt
    };

    private static Proceeding MapToDomain(ProceedingDocument document) => new()
    {
        Id = document.Id,
        Name = document.Name,
        Category = document.Category,
        Code = document.Code,
        TargetArea = document.TargetArea,
        DurationMinutes = document.DurationMinutes,
        SessionPrice = document.SessionPrice,
        SessionCount = document.SessionCount,
        RecoveryTime = document.RecoveryTime,
        Description = document.Description,
        Active = document.Active,
        CreatedAt = document.CreatedAt,
        UpdatedAt = document.UpdatedAt
    };
}
