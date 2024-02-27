using GerenciadorAluguel.Application.ServicesInterfaces;
using GerenciadorAluguel.Domain.Models;
using GerenciadorAluguel.Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.Api.Controllers.UsuarioController;

[ApiController]
[Route("api/gerenciamento/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("criar")]
    public async Task<IActionResult> Create([FromBody] UsuarioDto dto)
    {

        try
        {
            var resultado = new Usuario(dto.Nome,dto.Senha,dto.Email,dto.Role);
            await _usuarioService.AdicionarUsuario(resultado);
            return Ok("Usuário criado com sucesso.");
        }
        catch (Exception ex)
        {
            return StatusCode(400, $"Erro ao criar usuário");
        }
    }
}
