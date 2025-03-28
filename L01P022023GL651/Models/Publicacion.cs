using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L01P022023GL651.Models
{
    public class Publicacion
    {
        [Key]
        public int PublicacionId { get; set; }

        [Required]
        [StringLength(255)]
        public string Titulo { get; set; } = null!;

        [Required]
        public string Descripcion { get; set; } = null!;

        [ForeignKey("Usuario")]
        public int? UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
