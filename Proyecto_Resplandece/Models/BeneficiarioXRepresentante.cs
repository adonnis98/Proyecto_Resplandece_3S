using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("beneficiario_x_representante")]
[Index("IdRepresentante", Name = "FK_BR_Representante_idx")]
[Index("IdBeneficiario", "IdRepresentante", Name = "UQ_B_R", IsUnique = true)]
public partial class BeneficiarioXRepresentante
{
    [Key]
    [Column("Id_B_R")]
    public uint IdBR { get; set; }

    [Column("Id_Beneficiario")]
    public uint IdBeneficiario { get; set; }

    [Column("Id_Representante")]
    public uint IdRepresentante { get; set; }

    [Column("Fecha_Asignacion", TypeName = "datetime")]
    public DateTime FechaAsignacion { get; set; }

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string Estado { get; set; } = null!;

    [ForeignKey("IdBeneficiario")]
    [InverseProperty("BeneficiarioXRepresentantes")]
    public virtual Beneficiario IdBeneficiarioNavigation { get; set; } = null!;

    [ForeignKey("IdRepresentante")]
    [InverseProperty("BeneficiarioXRepresentantes")]
    public virtual Representante IdRepresentanteNavigation { get; set; } = null!;
}
