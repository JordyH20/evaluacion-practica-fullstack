using Microsoft.EntityFrameworkCore;
using PruebaFullStack.Data;
using PruebaFullStack.DTOs.Request;
using PruebaFullStack.Models;

namespace PruebaFullStack.Service
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }


        public async Task CreateUserAsync(UserRequest user)
        {
            var newUser = new Usuario
            {
                Nombre = user.Nombre,
                Correo = user.Correo,
                PasswordHash = user.Password, 
                Rol = user.Rol
            };
            _context.Usuarios.Add(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetAllUsersAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }


        public async Task<Usuario?> GetUserByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }


        public async Task UpdateUserAsync(int id, UserRequest updatedUser)
        {
            var existingUser = await _context.Usuarios.FindAsync(id);
            if (existingUser != null)
            {
                existingUser.Nombre = updatedUser.Nombre;
                existingUser.Correo = updatedUser.Correo;
                existingUser.PasswordHash = updatedUser.Password; 
                existingUser.Rol = updatedUser.Rol;
                await _context.SaveChangesAsync();
            }
        }



        public async Task DeleteUserAsync(int id)
        {
            var userToDelete = await _context.Usuarios.FindAsync(id);
            if (userToDelete != null)
            {
                _context.Usuarios.Remove(userToDelete);
                await _context.SaveChangesAsync();
            }
        }   
    }
}
