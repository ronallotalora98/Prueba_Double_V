using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Double_V.Application.DTOs;
using Prueba_Double_V.Application.Interfaces;
using Prueba_Double_V.DBContext;
using Prueba_Double_V.Domain.Models;

namespace Prueba_Double_V.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;


        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;

        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> PostUsuario(LoginRequest usuario)
        {
           return await _usuarioService.CrearUsuario(usuario);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var usuario =  await _usuarioService.GetLogin(loginRequest);
            return usuario;
        }
    }

}
