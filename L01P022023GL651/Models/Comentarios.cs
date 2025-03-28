using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L01P02NUMEROCARNET.Models
{
    public class Comentario
    {
        [Key]
        public int CometarioId { get; set; }

        [ForeignKey("Publicacion")]
        public int? PublicacionId { get; set; }

        public string? ComentarioTexto { get; set; }

        [ForeignKey("Usuario")]
        public int? UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }
        public Publicacion? Publicacion { get; set; }
    }
}
