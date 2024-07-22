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
    public class PersonaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonaDTO>>> GetPersonas()
        {
            return await _personaService.GetPersonas();
        }

        [HttpPost]
        public async Task<ActionResult<PersonaDTO>> PostPersona(PersonaDTO persona)
        {
            return await _personaService.CrearPersona(persona);
        }
    }
}
