using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("servicio_voluntariado")]
[Index("IdRepresentante", Name = "FK_SV_Representante_idx")]
[Index("RegistradoPor", Name = "FK_SV_Usuario_idx")]
public partial class ServicioVoluntariado
{
    [Key]
    [Column("Id_Servicio")]
    public uint IdServicio { get; set; }

    [Column("Id_Representante")]
    public uint IdRepresentante { get; set; }

    [Column("Fecha_Actividad")]
    public DateOnly FechaActividad { get; set; }

    [Column("Tipo_Servicio", TypeName = "enum('LIMPIEZA','SEGURIDAD','COCINA','EVENTO','MANUALIDADES')")]
    public string TipoServicio { get; set; } = null!;

    [Required]
    public bool? Asistencia { get; set; }

    [StringLength(255)]
    public string? Descripcion { get; set; }

    [Column("Registrado_Por")]
    public int RegistradoPor { get; set; }

    [Column(TypeName = "enum('COMPLETO','INCOMPLETO')")]
    public string Estado { get; set; } = null!;

    [ForeignKey("IdRepresentante")]
    [InverseProperty("ServicioVoluntariados")]
    public virtual Representante IdRepresentanteNavigation { get; set; } = null!;

    [ForeignKey("RegistradoPor")]
    [InverseProperty("ServicioVoluntariados")]
    public virtual Usuario RegistradoPorNavigation { get; set; } = null!;
}
