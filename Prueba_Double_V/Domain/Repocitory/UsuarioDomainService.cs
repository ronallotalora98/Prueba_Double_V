using Microsoft.EntityFrameworkCore;
using Prueba_Double_V.DBContext;
using Prueba_Double_V.Domain.Interfaces;
using Prueba_Double_V.Domain.Models;

namespace Prueba_Double_V.Domain.Repocitory
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly ApplicationDbContext _context;
        public UsuarioDomainService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CrearUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> GetUsuario(Usuario usuario)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.User == usuario.User && u.Pass == usuario.Pass);
        }
    }
}
