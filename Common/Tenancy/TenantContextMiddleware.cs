namespace Vyracare.Api.Proceedings.Common.Tenancy;

public sealed class TenantContextMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated == true &&
            (string.IsNullOrWhiteSpace(context.User.FindFirst("tenant_id")?.Value) ||
             string.IsNullOrWhiteSpace(context.User.FindFirst("membership_id")?.Value) ||
             string.IsNullOrWhiteSpace(context.User.FindFirst("tenant_role")?.Value)))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsJsonAsync(new { message = "Tenant context is required." });
            return;
        }

        await next(context);
    }
}
