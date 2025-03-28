namespace L01P022023GL651.Models
{
    public class Usuarios

    {
        public int usuarioId { get; set; }
        public string? usuarioNombre { get; set; }
        public string? usuarioApellido { get; set; }
        public string? usuarioCorreo { get; set; }
        public string? usuarioContrasena { get; set; }
        public int rolId { get; set; }
        public Rol? Rol { get; set; }
    }
}
