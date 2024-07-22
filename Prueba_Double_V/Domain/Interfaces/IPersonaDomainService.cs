using Prueba_Double_V.Domain.Models;

namespace Prueba_Double_V.Domain.Interfaces
{
    public interface IPersonaDomainService
    {
        Task<List<Persona>> GetPersonas();
        Task<Persona> CrearPersona(Persona persona);
    }
}
