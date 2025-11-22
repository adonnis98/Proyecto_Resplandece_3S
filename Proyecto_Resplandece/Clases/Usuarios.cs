using Proyecto_Resplandece.Clases.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Resplandece.Models
{
    [Table("USUARIOS")]
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("CODIGO")]
        [MaxLength(20)]
        [NotNull] // Indica que la propiedad nunca será null
        public string Codigo { get; set; } = string.Empty;

        [Required]
        [Column("USUARIO")]
        [MaxLength(50)]
        [NotNull]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Column("CONTRASENA_HASH")]
        [MaxLength(256)]
        [NotNull]
        public string ContrasenaHash { get; set; } = string.Empty;

        [Column("CONTRASENA_SALT")]
        [MaxLength(128)]
        public string? ContrasenaSalt { get; set; }

        [Required]
        [Column("ROL")]
        [MaxLength(20)]
        [NotNull]
        public string Rol { get; set; } = string.Empty;

        public Usuarios() { }
       public Usuarios(string codigo, string username, string contrasenaHash, string rol)
        {
            Codigo = codigo;
            Username = username;
            ContrasenaHash = contrasenaHash;
            Rol = rol;
        }
    }
}
