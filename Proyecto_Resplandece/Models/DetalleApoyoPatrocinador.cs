using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("detalle_apoyo_patrocinador")]
[Index("IdTipoApoyo", Name = "FK_DAP_TipoApoyo_idx")]
[Index("IdTransaccion", Name = "FK_DAP_Transaccion_idx")]
public partial class DetalleApoyoPatrocinador
{
    [Key]
    [Column("Id_DetalleApoyo")]
    public uint IdDetalleApoyo { get; set; }

    [Column("Id_Transaccion")]
    public uint IdTransaccion { get; set; }

    [Column("Id_TipoApoyo")]
    public uint IdTipoApoyo { get; set; }

    public int Cantidad { get; set; }

    [Column("Unidad_Medida")]
    [StringLength(50)]
    public string? UnidadMedida { get; set; }

    [StringLength(255)]
    public string? Observaciones { get; set; }

    [ForeignKey("IdTipoApoyo")]
    [InverseProperty("DetalleApoyoPatrocinadors")]
    public virtual TipoApoyo IdTipoApoyoNavigation { get; set; } = null!;

    [ForeignKey("IdTransaccion")]
    [InverseProperty("DetalleApoyoPatrocinadors")]
    public virtual TransaccionPatrocinador IdTransaccionNavigation { get; set; } = null!;
}
