using Microsoft.EntityFrameworkCore;
using Prueba_Double_V.DBContext;
using Prueba_Double_V.Domain.Interfaces;
using Prueba_Double_V.Domain.Models;
using System.Collections.ObjectModel;

namespace Prueba_Double_V.Domain.Repocitory
{
    public class PersonaDomainService : IPersonaDomainService
    {
        private readonly ApplicationDbContext _context;
        public PersonaDomainService(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<List<Persona>> GetPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> CrearPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return persona;
        }
    }
}
