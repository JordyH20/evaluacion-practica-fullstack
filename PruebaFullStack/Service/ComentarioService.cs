using Microsoft.EntityFrameworkCore;
using PruebaFullStack.Data;
using PruebaFullStack.DTOs.Request;
using PruebaFullStack.Models;

namespace PruebaFullStack.Service
{
    public class ComentarioService
    {
        private readonly AppDbContext _context;

        public ComentarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comentario>> GetAllAsync()
        {
            return await _context.Comentarios
                .Include(c => c.Usuario)
                .ToListAsync();
        }

        public async Task<Comentario?> GetByIdAsync(int id)
        {
            return await _context.Comentarios
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comentario> CreateAsync(ComentarioRequest request)
        {
            var comentario = new Comentario
            {
                Texto = request.Texto,
                UsuarioId = request.UsuarioId,
                PostId = request.PostId
            };

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return comentario;
        }

        public async Task<bool> UpdateAsync(int id, ComentarioRequest request)
        {
            var comentario = await _context.Comentarios.FindAsync(id);

            if (comentario == null)
                return false;

            comentario.Texto = request.Texto;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);

            if (comentario == null)
                return false;

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
