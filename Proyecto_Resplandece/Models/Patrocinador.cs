using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("patrocinador")]
[Index("Identificacion", Name = "Identificacion_UNIQUE", IsUnique = true)]
public partial class Patrocinador
{
    [Key]
    [Column("Id_Patrocinador")]
    public uint IdPatrocinador { get; set; }

    [Column("Nombre_RazonSocial")]
    [StringLength(200)]
    public string NombreRazonSocial { get; set; } = null!;

    [Column("Tipo_Identificacion", TypeName = "enum('CEDULA','RUC','PASAPORTE')")]
    public string TipoIdentificacion { get; set; } = null!;

    [StringLength(45)]
    public string Identificacion { get; set; } = null!;

    [StringLength(45)]
    public string? Telefono { get; set; }

    [StringLength(45)]
    public string? Correo { get; set; }

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string Estado { get; set; } = null!;

    [Column("Fecha_Registro", TypeName = "datetime")]
    public DateTime FechaRegistro { get; set; }

    [InverseProperty("IdPatrocinadorNavigation")]
    public virtual ICollection<TransaccionPatrocinador> TransaccionPatrocinadors { get; set; } = new List<TransaccionPatrocinador>();
}
