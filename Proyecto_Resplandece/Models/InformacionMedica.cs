using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("informacion_medica")]
public partial class InformacionMedica
{
    [Key]
    [Column("Id_Beneficiario")]
    public uint IdBeneficiario { get; set; }

    [Column("Grupo_Sanguineo")]
    [StringLength(45)]
    public string? GrupoSanguineo { get; set; }

    [StringLength(500)]
    public string? Alergias { get; set; }

    [Column("Condiciones_Medicas")]
    [StringLength(500)]
    public string? CondicionesMedicas { get; set; }

    [Column("Medicamentos_Actuales")]
    [StringLength(500)]
    public string? MedicamentosActuales { get; set; }

    [Column("Contacto_Emergencia")]
    [StringLength(100)]
    public string? ContactoEmergencia { get; set; }

    [Column("Telefono_Emergencia")]
    [StringLength(45)]
    public string? TelefonoEmergencia { get; set; }

    [Column("Fecha_Actualizacion", TypeName = "datetime")]
    public DateTime? FechaActualizacion { get; set; }

    [ForeignKey("IdBeneficiario")]
    [InverseProperty("InformacionMedica")]
    public virtual Beneficiario IdBeneficiarioNavigation { get; set; } = null!;
}
