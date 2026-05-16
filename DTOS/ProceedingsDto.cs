namespace Vyracare.Api.Proceedings.DTOS;

public record CreateProceedingsRequest(
    string Name,
    string? Description
);
