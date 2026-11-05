using Microsoft.Extensions.Hosting;

namespace PruebaFullStack.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string? Texto { get; set; }
        public DateTime FechaPublicacion { get; set; } = DateTime.Now;

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int PostId { get; set; }
       // public Post? Post { get; set; }
    }
}
