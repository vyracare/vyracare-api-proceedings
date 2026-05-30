using Microsoft.AspNetCore.Mvc;
using Vyracare.Api.Proceedings.Common.Results;

namespace Vyracare.Api.Proceedings.Common.Http;

/// <summary>
/// Centraliza extens?es reutiliz?veis usadas pela aplica??o.
/// </summary>
public static class ControllerBaseExtensions
{
    public static IActionResult ToActionResult<T>(
        this ControllerBase controller,
        UseCaseResult<T> result,
        Func<T, IActionResult> onSuccess)
    {
        if (result.IsSuccess)
        {
            return onSuccess(result.Value!);
        }

        var payload = new { message = result.Message };

        return result.ErrorType switch
        {
            UseCaseErrorType.Validation => controller.BadRequest(payload),
            UseCaseErrorType.Conflict => controller.Conflict(payload),
            UseCaseErrorType.NotFound => controller.NotFound(payload),
            _ => controller.BadRequest(payload)
        };
    }
}
