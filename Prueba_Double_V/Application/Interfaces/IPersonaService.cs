using Prueba_Double_V.Application.DTOs;

namespace Prueba_Double_V.Application.Interfaces
{
    public interface IPersonaService
    {
        Task<List<PersonaDTO>> GetPersonas();
        Task<PersonaDTO> CrearPersona(PersonaDTO personaDTO);
    }
}
