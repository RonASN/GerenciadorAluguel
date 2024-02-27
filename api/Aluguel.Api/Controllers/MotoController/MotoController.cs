using GerenciadorAluguel.Application.ServicesInterfaces;
using GerenciadorAluguel.Database.PostgreSQL;
using GerenciadorAluguel.Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.Api.Controllers.MotoController;
[ApiController]
[Route("api/gerenciamento/[controller]")]
public class MotoController : ControllerBase
{
    private readonly IMotoService _motoService;
    private readonly GerenciadorAluguelDbContext _context;

    public MotoController(GerenciadorAluguelDbContext context, IMotoService motoService)
    {
        _context = context;
        _motoService = motoService;
    }

    [HttpPost("criar")]
    public async Task<IActionResult> Create([FromQuery] Guid idUsuario, [FromBody] MotoDto dto)
    {
        try
        {
            await _motoService.AdicionarMoto(dto, idUsuario);
            return Ok("Moto criada com sucesso.");
        }
        catch (Exception ex)
        {
            return StatusCode(400, $"Erro ao criar moto");
        }
    }
    [HttpGet("buscar")]
    public async Task<IActionResult> Get([FromQuery] string? placa)
    {
        try
        {
            var resultado = await _motoService.BuscarMoto(placa);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(400, $"Erro ao buscar moto");
        }
    }
    [HttpGet("editar")]
    public async Task<IActionResult> Put([FromQuery] Guid idMoto ,[FromQuery] Guid idUsuario, [FromQuery] string? placa)
    {
        try
        {
            var resultado = await _motoService.EditarMoto(idUsuario,idMoto,placa);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(400, $"Erro ao editar moto");
        }
    }
    [HttpDelete("apagar")]
    public async Task<IActionResult> Put([FromQuery] Guid idUsuario, [FromQuery] Guid idMoto)
    {
        try
        {
            var resultado = await _motoService.ApagarMoto(idUsuario, idMoto);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(400, $"Erro ao buscar moto");
        }
    }

}
