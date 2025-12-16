using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("documento_beneficiario")]
[Index("IdBeneficiario", Name = "FK_Doc_Beneficiario_idx")]
public partial class DocumentoBeneficiario
{
    [Key]
    [Column("Id_Documento")]
    public int IdDocumento { get; set; }

    [Column("Id_Beneficiario")]
    public uint IdBeneficiario { get; set; }

    [Column("Tipo_Documento", TypeName = "enum('REPORTE_NOTAS','IDENTIFICACION','OTRO')")]
    public string TipoDocumento { get; set; } = null!;

    [Column("URL_Documento")]
    [StringLength(500)]
    public string UrlDocumento { get; set; } = null!;

    [Column("Fecha_Vigencia")]
    public DateOnly? FechaVigencia { get; set; }

    [Column("Fecha_Subida", TypeName = "datetime")]
    public DateTime FechaSubida { get; set; }

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string? Estado { get; set; }

    [ForeignKey("IdBeneficiario")]
    [InverseProperty("DocumentoBeneficiarios")]
    public virtual Beneficiario IdBeneficiarioNavigation { get; set; } = null!;
}
