using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("rol_x_opcion")]
[Index("IdOpcion", Name = "FK_RXR_Opcion_idx")]
[Index("IdRol", Name = "FK_RXR_Rol_idx")]
public partial class RolXOpcion
{
    [Key]
    [Column("Id_RolOpcion")]
    public uint IdRolOpcion { get; set; }

    [Column("Id_Rol")]
    public int IdRol { get; set; }

    [Column("Id_Opcion")]
    public uint IdOpcion { get; set; }

    [Required]
    public bool? Permitido { get; set; }

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string Estado { get; set; } = null!;

    [ForeignKey("IdOpcion")]
    [InverseProperty("RolXOpcions")]
    public virtual Opcion IdOpcionNavigation { get; set; } = null!;

    [ForeignKey("IdRol")]
    [InverseProperty("RolXOpcions")]
    public virtual Rol IdRolNavigation { get; set; } = null!;
}
