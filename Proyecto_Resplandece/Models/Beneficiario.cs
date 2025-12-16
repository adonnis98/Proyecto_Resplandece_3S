using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("beneficiarios")]
[Index("IdTutor", Name = "FK_Beneficiario_Tutor_idx")]
public partial class Beneficiario
{
    [Key]
    [Column("Id_Beneficiarios")]
    public uint IdBeneficiarios { get; set; }

    [Column("Id_Tutor")]
    public int IdTutor { get; set; }

    [StringLength(10)]
    public string Cedula { get; set; } = null!;

    [StringLength(200)]
    public string Nombres { get; set; } = null!;

    [StringLength(200)]
    public string Apellidos { get; set; } = null!;

    [StringLength(200)]
    public string Domicilio { get; set; } = null!;

    [StringLength(200)]
    public string Genero { get; set; } = null!;

    [Column("Fecha_Nacimiento")]
    public DateOnly FechaNacimiento { get; set; }

    public sbyte Discapacidad { get; set; }

    [Column("Tipo_Discapacidad")]
    [StringLength(100)]
    public string TipoDiscapacidad { get; set; } = null!;

    [StringLength(400)]
    public string Escuela { get; set; } = null!;

    [StringLength(45)]
    public string Curso { get; set; } = null!;

    [Column("Aplica Beca")]
    public sbyte AplicaBeca { get; set; }

    [StringLength(45)]
    public string Becado { get; set; } = null!;

    [Column("Fecha_Creacion", TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [Column("Fecha_Modificacion", TypeName = "datetime")]
    public DateTime FechaModificacion { get; set; }

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdBeneficiarioNavigation")]
    public virtual ICollection<BeneficiarioXRepresentante> BeneficiarioXRepresentantes { get; set; } = new List<BeneficiarioXRepresentante>();

    [InverseProperty("IdBeneficiarioNavigation")]
    public virtual ICollection<ContactosEmergencium> ContactosEmergencia { get; set; } = new List<ContactosEmergencium>();

    [InverseProperty("IdBeneficiarioNavigation")]
    public virtual ICollection<DocumentoBeneficiario> DocumentoBeneficiarios { get; set; } = new List<DocumentoBeneficiario>();

    [ForeignKey("IdTutor")]
    [InverseProperty("Beneficiarios")]
    public virtual Tutor IdTutorNavigation { get; set; } = null!;

    [InverseProperty("IdBeneficiarioNavigation")]
    public virtual InformacionMedica? InformacionMedica { get; set; }

    [InverseProperty("IdBeneficiarioNavigation")]
    public virtual ICollection<PagoColegiatura> PagoColegiaturas { get; set; } = new List<PagoColegiatura>();
}
