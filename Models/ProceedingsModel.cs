using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Vyracare.Api.Proceedings.Models;

public class ProceedingsModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = null!;

    [BsonElement("category")]
    public string Category { get; set; } = null!;

    [BsonElement("code")]
    public string Code { get; set; } = null!;

    [BsonElement("targetArea")]
    public string TargetArea { get; set; } = null!;

    [BsonElement("durationMinutes")]
    public int DurationMinutes { get; set; }

    [BsonElement("sessionPrice")]
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal SessionPrice { get; set; }

    [BsonElement("sessionCount")]
    public int SessionCount { get; set; }

    [BsonElement("recoveryTime")]
    public string RecoveryTime { get; set; } = null!;

    [BsonElement("description")]
    public string Description { get; set; } = null!;

    [BsonElement("active")]
    public bool Active { get; set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
