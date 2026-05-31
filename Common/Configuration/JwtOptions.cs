namespace Vyracare.Api.Proceedings.Common.Configuration;

/// <summary>
/// Representa as opções de configuração carregadas da aplicação.
/// </summary>
public sealed class JwtOptions
{
    public const string SectionName = "Jwt";

/// <summary>
/// Obtém ou define a chave usada no processo de autenticação ou assinatura.
/// </summary>
    public string Key { get; set; } = string.Empty;
/// <summary>
/// Obtém ou define o emissor considerado válido para o token.
/// </summary>
    public string Issuer { get; set; } = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_yZNKvAZTf";
/// <summary>
/// Obtém ou define o público considerado válido para o token.
/// </summary>
    public string Audience { get; set; } = "424aitrab2nma4ttgi0314dfst";
}
