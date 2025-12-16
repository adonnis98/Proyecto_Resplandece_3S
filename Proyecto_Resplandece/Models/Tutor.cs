using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("tutor")]
[Index("IdTutor", Name = "Id_GrupoEtario_UNIQUE", IsUnique = true)]
public partial class Tutor
{
    [Key]
    [Column("Id_Tutor")]
    public int IdTutor { get; set; }

    [StringLength(200)]
    public string Nombres { get; set; } = null!;

    [StringLength(200)]
    public string Apellidos { get; set; } = null!;

    [StringLength(45)]
    public string Telefono { get; set; } = null!;

    [Column("Edad_Minima")]
    public int EdadMinima { get; set; }

    [Column("Edad_Maxima")]
    public int EdadMaxima { get; set; }

    [Column("Fecha_Creacion", TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [Column("Fecha_Modificacion", TypeName = "datetime")]
    public DateTime FechaModificacion { get; set; }

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdTutorNavigation")]
    public virtual ICollection<Beneficiario> Beneficiarios { get; set; } = new List<Beneficiario>();
}
