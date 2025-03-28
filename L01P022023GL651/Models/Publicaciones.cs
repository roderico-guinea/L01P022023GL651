namespace L01P022023GL651.Models
{
    public class Publicaciones

    {
        public int publicacionId { get; set; }
        public string? publicacionTitulo { get; set; }
        public string? publicacionContenido { get; set; }
        public int usuarioId { get; set; }
        public Usuarios? Usuario { get; set; }
    }
}
