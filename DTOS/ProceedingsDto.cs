namespace Vyracare.Api.Proceedings.DTOS;

public record CreateProceedingsRequest(
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
