using GerenciadorAluguel.Application.Services;
using GerenciadorAluguel.Application.ServicesInterfaces;
using GerenciadorAluguel.Database.PostgreSQL;
using GerenciadorAluguel.Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.Api.Controllers.EntregadorController;

public class EntregadorController : ControllerBase
{
    private readonly IEntregadorService _entregadorService;
    private readonly GerenciadorAluguelDbContext _context;

    public EntregadorController(GerenciadorAluguelDbContext context, IEntregadorService entregadorService)
    {
        _context = context;
        _entregadorService = entregadorService;
    }

    [HttpPost("criar")]
    public async Task<IActionResult> Create([FromQuery] Guid idUsuario, [FromBody] EntregadorDto dto)
    {
        try
        {
            await _entregadorService.CadastrarEntregador(idUsuario,dto);
            return Ok("Moto criada com sucesso.");
        }
        catch (Exception ex)
        {
            return StatusCode(400, $"Erro ao criar moto");
        }
    }
}
