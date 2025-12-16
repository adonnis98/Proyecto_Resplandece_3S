using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("contactos_emergencia")]
[Index("IdBeneficiario", Name = "FK_CE_Beneficiario_idx")]
public partial class ContactosEmergencium
{
    [Key]
    [Column("Id_Contacto")]
    public uint IdContacto { get; set; }

    [Column("Id_Beneficiario")]
    public uint IdBeneficiario { get; set; }

    [Column("Nombre_Completo")]
    [StringLength(400)]
    public string NombreCompleto { get; set; } = null!;

    [Column("Telefono_Principal")]
    [StringLength(50)]
    public string TelefonoPrincipal { get; set; } = null!;

    [StringLength(50)]
    public string? Parentesco { get; set; }

    [Required]
    public bool? Prioridad { get; set; }

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string Estado { get; set; } = null!;

    [ForeignKey("IdBeneficiario")]
    [InverseProperty("ContactosEmergencia")]
    public virtual Beneficiario IdBeneficiarioNavigation { get; set; } = null!;
}
