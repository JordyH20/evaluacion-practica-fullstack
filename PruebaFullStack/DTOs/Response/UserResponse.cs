using PruebaFullStack.Models;

namespace PruebaFullStack.DTOs.Response
{
    public class UserResponse
    {
       public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public RolUsuario Rol { get; set; } = new RolUsuario();
    }
}
