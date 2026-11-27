using System.Security.Claims;

namespace Vyracare.Api.Proceedings.Common.Tenancy;

public interface ITenantContext
{
    string TenantId { get; }
    string MembershipId { get; }
    string Role { get; }
}

public sealed class HttpTenantContext(IHttpContextAccessor accessor) : ITenantContext
{
    public string TenantId => Required("tenant_id");
    public string MembershipId => Required("membership_id");
    public string Role => Required("tenant_role");

    private string Required(string claim)
    {
        var value = accessor.HttpContext?.User.FindFirstValue(claim);
        return !string.IsNullOrWhiteSpace(value)
            ? value
            : throw new InvalidOperationException($"Required tenant claim '{claim}' is missing.");
    }
}
