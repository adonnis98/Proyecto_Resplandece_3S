using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("tipo_apoyo")]
[Index("Nombre", Name = "Nombre_UNIQUE", IsUnique = true)]
public partial class TipoApoyo
{
    [Key]
    [Column("Id_TipoApoyo")]
    public uint IdTipoApoyo { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(255)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdTipoApoyoNavigation")]
    public virtual ICollection<DetalleApoyoPatrocinador> DetalleApoyoPatrocinadors { get; set; } = new List<DetalleApoyoPatrocinador>();
}
