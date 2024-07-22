using AutoMapper;
using Prueba_Double_V.Application.DTOs;
using Prueba_Double_V.Application.Interfaces;
using Prueba_Double_V.Domain.Interfaces;
using Prueba_Double_V.Domain.Models;

namespace Prueba_Double_V.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaDomainService _personaDomainService;
        private readonly IMapper _mapper;
        public PersonaService(IPersonaDomainService personaDomainService, IMapper mapper)
        {
            _personaDomainService = personaDomainService;
            _mapper = mapper;
        }

        public async Task<List<PersonaDTO>> GetPersonas()
        {
            try
            {
                var personas = await _personaDomainService.GetPersonas();
                return _mapper.Map<List<PersonaDTO>>(personas);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<PersonaDTO> CrearPersona(PersonaDTO personaDTO)
        {
            try
            {
                personaDTO.FechaCreacion = DateTime.Now;
                var persona = await _personaDomainService.CrearPersona(_mapper.Map<Persona>(personaDTO));
                return _mapper.Map<PersonaDTO>(persona);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
