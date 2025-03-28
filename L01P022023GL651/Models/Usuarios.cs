﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L01P022023GL651.Models
{
    public class Usuarios

    {
        [Key]
        public int UsuarioId { get; set; }

        [ForeignKey("Rol")]
        public int RolId { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Clave { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; } = null!;

        public Rol? Rol { get; set; }
    }
}
