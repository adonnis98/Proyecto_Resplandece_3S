using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("pago_colegiatura")]
[Index("IdBeneficiario", Name = "FK_Pago_Beneficiario_idx")]
public partial class PagoColegiatura
{
    [Key]
    [Column("Id_Pago")]
    public uint IdPago { get; set; }

    [Column("Id_Beneficiario")]
    public uint IdBeneficiario { get; set; }

    [Column("Fecha_Pago")]
    public DateOnly FechaPago { get; set; }

    [Precision(10, 2)]
    public decimal Monto { get; set; }

    [Column("Metodo_Pago", TypeName = "enum('EFECTIVO','TRANSFERENCIA','TARJETA')")]
    public string MetodoPago { get; set; } = null!;

    [Column("Referencia_Transaccion")]
    [StringLength(100)]
    public string? ReferenciaTransaccion { get; set; }

    [Column(TypeName = "enum('PAGADO','PENDIENTE','CANCELADO')")]
    public string Estado { get; set; } = null!;

    [Column("Fecha_Creacion", TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [ForeignKey("IdBeneficiario")]
    [InverseProperty("PagoColegiaturas")]
    public virtual Beneficiario IdBeneficiarioNavigation { get; set; } = null!;
}
