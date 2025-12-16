using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("opcion")]
[Index("NombreFormulario", Name = "Nombre_Opcion_UNIQUE", IsUnique = true)]
public partial class Opcion
{
    [Key]
    [Column("Id_Opcion")]
    public uint IdOpcion { get; set; }

    [StringLength(100)]
    public string Descripcion { get; set; } = null!;

    [Column("Nombre_Formulario")]
    [StringLength(100)]
    public string NombreFormulario { get; set; } = null!;

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string Estado { get; set; } = null!;

    [Column("Fecha_Creacion", TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [Column("Fecha_Modificacion", TypeName = "datetime")]
    public DateTime FechaModificacion { get; set; }

    [InverseProperty("IdOpcionNavigation")]
    public virtual ICollection<RolXOpcion> RolXOpcions { get; set; } = new List<RolXOpcion>();
}
