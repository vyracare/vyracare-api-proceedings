using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Vyracare.Api.Proceedings.Infrastructure.Persistence.Documents;

/// <summary>
/// Representa o formato persistido no MongoDB para esta entidade.
/// </summary>
public sealed class ProceedingDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
/// <summary>
/// Identificador do registro ou do recurso processado.
/// </summary>
    public string? Id { get; set; }

    [BsonElement("name")]
/// <summary>
/// Nome principal associado ao recurso.
/// </summary>
    public string Name { get; set; } = string.Empty;

    [BsonElement("category")]
/// <summary>
/// Obt?m ou define c at eg or y.
/// </summary>
    public string Category { get; set; } = string.Empty;

    [BsonElement("code")]
/// <summary>
/// C?digo interno usado para identificar o recurso no dom?nio.
/// </summary>
    public string Code { get; set; } = string.Empty;

    [BsonElement("targetArea")]
/// <summary>
/// Obt?m ou define t ar ge ta re a.
/// </summary>
    public string TargetArea { get; set; } = string.Empty;

    [BsonElement("durationMinutes")]
/// <summary>
/// Obt?m ou define d ur at io nm in ut es.
/// </summary>
    public int DurationMinutes { get; set; }

    [BsonElement("sessionPrice")]
    [BsonRepresentation(BsonType.Decimal128)]
/// <summary>
/// Obt?m ou define s es si on pr ic e.
/// </summary>
    public decimal SessionPrice { get; set; }

    [BsonElement("sessionCount")]
/// <summary>
/// Obt?m ou define s es si on co un t.
/// </summary>
    public int SessionCount { get; set; }

    [BsonElement("recoveryTime")]
/// <summary>
/// Obt?m ou define r ec ov er yt im e.
/// </summary>
    public string RecoveryTime { get; set; } = string.Empty;

    [BsonElement("description")]
/// <summary>
/// Descri??o textual usada para complementar o entendimento do recurso.
/// </summary>
    public string Description { get; set; } = string.Empty;

    [BsonElement("active")]
/// <summary>
/// Obt?m ou define a ct iv e.
/// </summary>
    public bool Active { get; set; }

    [BsonElement("createdAt")]
/// <summary>
/// Data de cria??o do registro.
/// </summary>
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
/// <summary>
/// Data da ?ltima atualiza??o do registro.
/// </summary>
    public DateTime UpdatedAt { get; set; }
}
