namespace PruebaFullStack.DTOs.Request
{
    public class ComentarioRequest
    {
        public string? Texto { get; set; }
        public int UsuarioId { get; set; }
        public int PostId { get; set; }
    }
}
