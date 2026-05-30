using Microsoft.AspNetCore.Mvc;
using Vyracare.Api.Proceedings.Common.Http;
using Vyracare.Api.Proceedings.Features.Proceedings.Create;
using Vyracare.Api.Proceedings.Features.Proceedings.GetById;
using Vyracare.Api.Proceedings.Features.Proceedings.List;

namespace Vyracare.Api.Proceedings.Features.Proceedings;

[ApiController]
[Route("api/proceedings")]
public sealed class ProceedingsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] ListProceedingsHandler handler)
    {
        var result = await handler.HandleAsync();
        return this.ToActionResult(result, Ok);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, [FromServices] GetProceedingByIdHandler handler)
    {
        var result = await handler.HandleAsync(id);
        return this.ToActionResult(result, Ok);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProceedingRequest request, [FromServices] CreateProceedingHandler handler)
    {
        var result = await handler.HandleAsync(request);
        return this.ToActionResult(result, value => CreatedAtAction(nameof(GetById), new { id = value.Id }, value));
    }
}
