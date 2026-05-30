namespace Vyracare.Api.Proceedings.Common.Configuration;

public sealed class JwtOptions
{
    public const string SectionName = "Jwt";

    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_yZNKvAZTf";
    public string Audience { get; set; } = "424aitrab2nma4ttgi0314dfst";
}
