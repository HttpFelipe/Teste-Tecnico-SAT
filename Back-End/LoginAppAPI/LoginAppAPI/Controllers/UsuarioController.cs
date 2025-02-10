using LoginAppAPI.DTOs;
using LoginAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoginAppAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("usuario/cadastrar")]
        public async Task<IActionResult> CadastrarUsuario(UsuarioRequestModel usuarioRequestModel)
        {
            var result = await _usuarioService.CadastrarUsuario(usuarioRequestModel);

            if (result.Error)
            {
                return BadRequest(new { message = result.Body });
            }

            return Ok();
        }

        [HttpPost("usuario/login")]
        public async Task<IActionResult> LoginUsuario(UsuarioRequestModel usuarioRequestModel)
        {
            var result = await _usuarioService.LoginUsuario(usuarioRequestModel);

            if (result.Error)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("usuarios")]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var result = await _usuarioService.BuscarUsuarios();

            if (result.Error)
            {
                return BadRequest(new { message = result.Body });
            }

            return Ok(new { usuarios = result.Usuarios });
        }
    }
}