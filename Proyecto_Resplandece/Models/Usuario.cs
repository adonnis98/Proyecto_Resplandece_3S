using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("usuario")]
[Index("Username", Name = "Username_UNIQUE", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("Id_Usuario")]
    public int IdUsuario { get; set; }

    [StringLength(100)]
    public string Username { get; set; } = null!;

    [StringLength(100)]
    public string Nombres { get; set; } = null!;

    [StringLength(100)]
    public string Apellidos { get; set; } = null!;

    [Column("Contrasena_Hash")]
    [StringLength(100)]
    public string ContrasenaHash { get; set; } = null!;

    [Column("Contrasena_Salt")]
    [StringLength(100)]
    public string? ContrasenaSalt { get; set; }

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string Estado { get; set; } = null!;

    [Column("Fecha_Creacion", TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [Column("Fecha_Modificacion", TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    [InverseProperty("RegistradoPorNavigation")]
    public virtual ICollection<ServicioVoluntariado> ServicioVoluntariados { get; set; } = new List<ServicioVoluntariado>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<UsuarioXRol> UsuarioXRols { get; set; } = new List<UsuarioXRol>();
}
