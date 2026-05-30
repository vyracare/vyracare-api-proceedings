namespace Vyracare.Api.Proceedings.Features.Proceedings.Create;

public sealed record CreateProceedingRequest(
    string Name,
    string Category,
    string Code,
    string TargetArea,
    int DurationMinutes,
    decimal SessionPrice,
    int SessionCount,
    string RecoveryTime,
    string Description,
    bool Active
);
