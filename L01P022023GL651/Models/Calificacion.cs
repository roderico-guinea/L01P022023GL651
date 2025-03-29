using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L01P022023GL651.Models
{
    public class Calificacion
    {
        [Key]
        public int CalificacionId { get; set; }

        [ForeignKey("Publicacion")]
        public int? PublicacionId { get; set; }

        [ForeignKey("Usuario")]
        public int? UsuarioId { get; set; }

        [Column("calificacion")]
        public int? Valor { get; set; }

        public Usuario? Usuario { get; set; }
        public Publicacion? Publicacion { get; set; }
    }
}
