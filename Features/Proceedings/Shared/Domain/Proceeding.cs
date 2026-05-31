namespace Vyracare.Api.Proceedings.Features.Proceedings.Shared.Domain;

/// <summary>
/// Representa a entidade de domínio principal desta feature.
/// </summary>
public sealed class Proceeding
{
/// <summary>
/// Obtém ou define o identificador do registro.
/// </summary>
    public string? Id { get; set; }
/// <summary>
/// Obtém ou define o valor da propriedade N am e.
/// </summary>
    public string Name { get; set; } = string.Empty;
/// <summary>
/// Obtém ou define a categoria associada ao registro.
/// </summary>
    public string Category { get; set; } = string.Empty;
/// <summary>
/// Obtém ou define o código interno do registro.
/// </summary>
    public string Code { get; set; } = string.Empty;
/// <summary>
/// Obtém ou define a área principal atendida pelo registro.
/// </summary>
    public string TargetArea { get; set; } = string.Empty;
/// <summary>
/// Obtém ou define a duração prevista em minutos.
/// </summary>
    public int DurationMinutes { get; set; }
/// <summary>
/// Obtém ou define o valor cobrado por sessão.
/// </summary>
    public decimal SessionPrice { get; set; }
/// <summary>
/// Obtém ou define a quantidade de sessões prevista.
/// </summary>
    public int SessionCount { get; set; }
/// <summary>
/// Obtém ou define o tempo estimado de recuperação.
/// </summary>
    public string RecoveryTime { get; set; } = string.Empty;
/// <summary>
/// Obtém ou define a descrição associada ao registro.
/// </summary>
    public string Description { get; set; } = string.Empty;
/// <summary>
/// Obtém ou define se o registro está ativo.
/// </summary>
    public bool Active { get; set; }
/// <summary>
/// Obtém ou define a data de criação do registro.
/// </summary>
    public DateTime CreatedAt { get; set; }
/// <summary>
/// Obtém ou define a data da última atualização do registro.
/// </summary>
    public DateTime UpdatedAt { get; set; }
}
