namespace Vyracare.Api.Proceedings.Features.Proceedings.Create;

/// <summary>
/// Define o contrato de entrada ou saída usado por esta feature.
/// </summary>
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
