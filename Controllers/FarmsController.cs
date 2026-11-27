using Microsoft.AspNetCore.Mvc;
using Umuhinzi.Dtos;
using Umuhinzi.Services;

namespace Umuhinzi.Controller;

[ApiController]
[Route("api/[controoler]")]

public class FarmsController(IFarmService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<FarmResponse>>> GetAll(CancellationToken ct) =>
        Ok(await service.GetAllAsync(ct));

    [HttpGet("{id:long}")]
    public async Task<ActionResult<FarmResponse>> GetById(long id, CancellationToken ct) =>
        Ok(await service.GetByIdAsync(id, ct));

    [HttpPost]
    public async Task<ActionResult<FarmResponse>> Create(CreateFarmRequest request, CancellationToken ct)
    {
        var farm = await service.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetById), new { id = farm.Id }, farm);
    }
}
