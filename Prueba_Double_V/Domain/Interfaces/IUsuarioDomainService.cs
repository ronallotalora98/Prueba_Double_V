using Prueba_Double_V.Domain.Models;

namespace Prueba_Double_V.Domain.Interfaces
{
    public interface IUsuarioDomainService
    {
        Task<Usuario> CrearUsuario(Usuario usuario);
        Task<Usuario> GetUsuario(Usuario usuario);
    }
}
