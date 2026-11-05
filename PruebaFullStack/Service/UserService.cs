using Microsoft.EntityFrameworkCore;
using PruebaFullStack.Data;
using PruebaFullStack.DTOs.Request;
using PruebaFullStack.DTOs.Response;
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

        public async Task<List<UserResponse>> GetAllUsersAsync()
        {
            var users = await _context.Usuarios.ToListAsync();
            return users.Select(u => new UserResponse
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Correo = u.Correo,
                Rol = u.Rol
            }).ToList();
        }


        public async Task<UserResponse?> GetUserByIdAsync(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if (user == null) return null;

            return new UserResponse
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Correo = user.Correo,
                Rol = user.Rol
            };
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
