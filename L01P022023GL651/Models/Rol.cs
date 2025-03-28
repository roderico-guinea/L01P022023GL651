using System.ComponentModel.DataAnnotations;

namespace L01P022023GL651.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [Required]
        [StringLength(100)]
        public string RolNombre { get; set; } = null!;
    }
}
