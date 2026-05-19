using Microsoft.AspNetCore.Mvc;
using Vyracare.Api.Proceedings.DTOS;
using Vyracare.Api.Proceedings.Models;
using Vyracare.Api.Proceedings.Services;

namespace Vyracare.Api.Proceedings.Controllers;

[ApiController]
[Route("api/proceedings")]
public class ProceedingsController : ControllerBase
{
    private readonly ProceedingsService _service;

    public ProceedingsController(ProceedingsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var item = await _service.GetByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProceedingsRequest request)
    {
        var item = new ProceedingsModel
        {
            Name = request.Name,
            Category = request.Category,
            Code = request.Code,
            TargetArea = request.TargetArea,
            DurationMinutes = request.DurationMinutes,
            SessionPrice = request.SessionPrice,
            SessionCount = request.SessionCount,
            RecoveryTime = request.RecoveryTime,
            Description = request.Description,
            Active = request.Active
        };

        await _service.CreateAsync(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }
}
