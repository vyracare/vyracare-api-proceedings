namespace Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;

public sealed class Proceeding
{
    public string? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string TargetArea { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public decimal SessionPrice { get; set; }
    public int SessionCount { get; set; }
    public string RecoveryTime { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
