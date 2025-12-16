using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("transaccion_patrocinador")]
[Index("IdPatrocinador", Name = "FK_Transaccion_Patrocinador")]
public partial class TransaccionPatrocinador
{
    [Key]
    [Column("Id_Transaccion")]
    public uint IdTransaccion { get; set; }

    [Column("Id_Patrocinador")]
    public uint IdPatrocinador { get; set; }

    [Column("Fecha_Transaccion", TypeName = "datetime")]
    public DateTime FechaTransaccion { get; set; }

    [Precision(10, 2)]
    public decimal Monto { get; set; }

    [Column("Tipo_Donacion", TypeName = "enum('EFECTIVO','TRANSFERENCIA','ESPECIE')")]
    public string TipoDonacion { get; set; } = null!;

    [StringLength(100)]
    public string? Comprobante { get; set; }

    [StringLength(255)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "enum('COMPLETADA','ANULADA')")]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdTransaccionNavigation")]
    public virtual ICollection<DetalleApoyoPatrocinador> DetalleApoyoPatrocinadors { get; set; } = new List<DetalleApoyoPatrocinador>();

    [ForeignKey("IdPatrocinador")]
    [InverseProperty("TransaccionPatrocinadors")]
    public virtual Patrocinador IdPatrocinadorNavigation { get; set; } = null!;
}
