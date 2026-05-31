using Microsoft.AspNetCore.Mvc;
using Vyracare.Api.Proceedings.Common.Http;
using Vyracare.Api.Proceedings.Features.Proceedings.Create;
using Vyracare.Api.Proceedings.Features.Proceedings.GetById;
using Vyracare.Api.Proceedings.Features.Proceedings.List;

namespace Vyracare.Api.Proceedings.Features.Proceedings;

[ApiController]
[Route("api/proceedings")]
/// <summary>
/// Expõe os endpoints HTTP da feature e delega o processamento aos handlers da aplicação.
/// </summary>
public sealed class ProceedingsController : ControllerBase
{
    [HttpGet]
/// <summary>
/// Executa a responsabilidade do método G et Al l.
/// </summary>
    public async Task<IActionResult> GetAll([FromServices] ListProceedingsHandler handler)
    {
        var result = await handler.HandleAsync();
        return this.ToActionResult(result, Ok);
    }

    [HttpGet("{id}")]
/// <summary>
/// Executa a responsabilidade do método G et By Id.
/// </summary>
    public async Task<IActionResult> GetById(string id, [FromServices] GetProceedingByIdHandler handler)
    {
        var result = await handler.HandleAsync(id);
        return this.ToActionResult(result, Ok);
    }

    [HttpPost]
/// <summary>
/// Executa a responsabilidade do método C re at e.
/// </summary>
    public async Task<IActionResult> Create([FromBody] CreateProceedingRequest request, [FromServices] CreateProceedingHandler handler)
    {
        var result = await handler.HandleAsync(request);
        return this.ToActionResult(result, value => CreatedAtAction(nameof(GetById), new { id = value.Id }, value));
    }
}
