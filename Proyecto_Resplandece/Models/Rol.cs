using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("rol")]
[Index("NombreRol", Name = "Codigo_UNIQUE", IsUnique = true)]
public partial class Rol
{
    [Key]
    [Column("Id_Rol")]
    public int IdRol { get; set; }

    [Column("Nombre_Rol")]
    [StringLength(100)]
    public string NombreRol { get; set; } = null!;

    [StringLength(100)]
    public string Descripcion { get; set; } = null!;

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string Estado { get; set; } = null!;

    [Column("Fecha_Creacion", TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [Column("Fecha_Modificacion", TypeName = "datetime")]
    public DateTime FechaModificacion { get; set; }

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<RolXOpcion> RolXOpcions { get; set; } = new List<RolXOpcion>();

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<UsuarioXRol> UsuarioXRols { get; set; } = new List<UsuarioXRol>();
}
