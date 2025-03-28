using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L01P022023GL651.Models
{
    public class Publicaciones
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

    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
