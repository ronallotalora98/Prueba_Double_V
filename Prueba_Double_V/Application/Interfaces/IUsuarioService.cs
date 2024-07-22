using Prueba_Double_V.Application.DTOs;

namespace Prueba_Double_V.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> CrearUsuario(LoginRequest usuario);
        Task<LoginResponse> GetLogin(LoginRequest usuario);
    }
}
