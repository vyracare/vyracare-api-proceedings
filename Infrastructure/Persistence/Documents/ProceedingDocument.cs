using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Vyracare.Api.Proceedings.Infrastructure.Persistence.Documents;

public sealed class ProceedingDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("category")]
    public string Category { get; set; } = string.Empty;

    [BsonElement("code")]
    public string Code { get; set; } = string.Empty;

    [BsonElement("targetArea")]
    public string TargetArea { get; set; } = string.Empty;

    [BsonElement("durationMinutes")]
    public int DurationMinutes { get; set; }

    [BsonElement("sessionPrice")]
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal SessionPrice { get; set; }

    [BsonElement("sessionCount")]
    public int SessionCount { get; set; }

    [BsonElement("recoveryTime")]
    public string RecoveryTime { get; set; } = string.Empty;

    [BsonElement("description")]
    public string Description { get; set; } = string.Empty;

    [BsonElement("active")]
    public bool Active { get; set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }
}
