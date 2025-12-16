using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("usuario_x_rol")]
[Index("IdRol", Name = "FK_UXR_Rol_idx")]
[Index("IdUsuario", "IdRol", Name = "UQ_UsuarioRol", IsUnique = true)]
public partial class UsuarioXRol
{
    [Key]
    [Column("Id_UsuarioRol")]
    public uint IdUsuarioRol { get; set; }

    [Column("Id_Usuario")]
    public int IdUsuario { get; set; }

    [Column("Id_Rol")]
    public int IdRol { get; set; }

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string Estado { get; set; } = null!;

    [ForeignKey("IdRol")]
    [InverseProperty("UsuarioXRols")]
    public virtual Rol IdRolNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("UsuarioXRols")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
