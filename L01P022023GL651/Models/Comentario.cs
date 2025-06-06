﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L01P022023GL651.Models
{
    public class Comentario
    {
        [Key]
        public int CometarioId { get; set; }

        [ForeignKey("Publicacion")]
        public int? PublicacionId { get; set; }

        [Column("comentario")]
        public string? Texto { get; set; }

        [ForeignKey("Usuario")]
        public int? UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }
        public Publicacion? Publicacion { get; set; }
    }
}
