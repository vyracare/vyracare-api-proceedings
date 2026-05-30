namespace Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;

/// <summary>
/// Representa uma parte da arquitetura desta API.
/// </summary>
public sealed class Proceeding
{
/// <summary>
/// Identificador do registro ou do recurso processado.
/// </summary>
    public string? Id { get; set; }
/// <summary>
/// Nome principal associado ao recurso.
/// </summary>
    public string Name { get; set; } = string.Empty;
/// <summary>
/// Obt?m ou define c at eg or y.
/// </summary>
    public string Category { get; set; } = string.Empty;
/// <summary>
/// C?digo interno usado para identificar o recurso no dom?nio.
/// </summary>
    public string Code { get; set; } = string.Empty;
/// <summary>
/// Obt?m ou define t ar ge ta re a.
/// </summary>
    public string TargetArea { get; set; } = string.Empty;
/// <summary>
/// Obt?m ou define d ur at io nm in ut es.
/// </summary>
    public int DurationMinutes { get; set; }
/// <summary>
/// Obt?m ou define s es si on pr ic e.
/// </summary>
    public decimal SessionPrice { get; set; }
/// <summary>
/// Obt?m ou define s es si on co un t.
/// </summary>
    public int SessionCount { get; set; }
/// <summary>
/// Obt?m ou define r ec ov er yt im e.
/// </summary>
    public string RecoveryTime { get; set; } = string.Empty;
/// <summary>
/// Descri??o textual usada para complementar o entendimento do recurso.
/// </summary>
    public string Description { get; set; } = string.Empty;
/// <summary>
/// Obt?m ou define a ct iv e.
/// </summary>
    public bool Active { get; set; }
/// <summary>
/// Data de cria??o do registro.
/// </summary>
    public DateTime CreatedAt { get; set; }
/// <summary>
/// Data da ?ltima atualiza??o do registro.
/// </summary>
    public DateTime UpdatedAt { get; set; }
}
