using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Vyracare.Api.Proceedings.Infrastructure.Persistence.Documents;

/// <summary>
/// Representa o documento persistido no MongoDB para esta feature.
/// </summary>
public sealed class ProceedingDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
/// <summary>
/// Obtém ou define o identificador do registro.
/// </summary>
    public string? Id { get; set; }

    [BsonElement("name")]
/// <summary>
/// Obtém ou define o valor da propriedade N am e.
/// </summary>
    public string Name { get; set; } = string.Empty;

    [BsonElement("category")]
/// <summary>
/// Obtém ou define a categoria associada ao registro.
/// </summary>
    public string Category { get; set; } = string.Empty;

    [BsonElement("code")]
/// <summary>
/// Obtém ou define o código interno do registro.
/// </summary>
    public string Code { get; set; } = string.Empty;

    [BsonElement("targetArea")]
/// <summary>
/// Obtém ou define a área principal atendida pelo registro.
/// </summary>
    public string TargetArea { get; set; } = string.Empty;

    [BsonElement("durationMinutes")]
/// <summary>
/// Obtém ou define a duração prevista em minutos.
/// </summary>
    public int DurationMinutes { get; set; }

    [BsonElement("sessionPrice")]
    [BsonRepresentation(BsonType.Decimal128)]
/// <summary>
/// Obtém ou define o valor cobrado por sessão.
/// </summary>
    public decimal SessionPrice { get; set; }

    [BsonElement("sessionCount")]
/// <summary>
/// Obtém ou define a quantidade de sessões prevista.
/// </summary>
    public int SessionCount { get; set; }

    [BsonElement("recoveryTime")]
/// <summary>
/// Obtém ou define o tempo estimado de recuperação.
/// </summary>
    public string RecoveryTime { get; set; } = string.Empty;

    [BsonElement("description")]
/// <summary>
/// Obtém ou define a descrição associada ao registro.
/// </summary>
    public string Description { get; set; } = string.Empty;

    [BsonElement("active")]
/// <summary>
/// Obtém ou define se o registro está ativo.
/// </summary>
    public bool Active { get; set; }

    [BsonElement("createdAt")]
/// <summary>
/// Obtém ou define a data de criação do registro.
/// </summary>
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
/// <summary>
/// Obtém ou define a data da última atualização do registro.
/// </summary>
    public DateTime UpdatedAt { get; set; }
}
