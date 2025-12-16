using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Resplandece.Models;

[Table("representantes")]
[Index("Cedula", Name = "Cedula_UNIQUE", IsUnique = true)]
[Index("IdRepresentante", Name = "Id_Representante_UNIQUE", IsUnique = true)]
public partial class Representante
{
    [Key]
    [Column("Id_Representante")]
    public uint IdRepresentante { get; set; }

    [StringLength(10)]
    public string Cedula { get; set; } = null!;

    [StringLength(100)]
    public string Nombres { get; set; } = null!;

    [StringLength(100)]
    public string Apellidos { get; set; } = null!;

    [StringLength(45)]
    public string Telefono { get; set; } = null!;

    [StringLength(45)]
    public string Parentesco { get; set; } = null!;

    [StringLength(400)]
    public string Correo { get; set; } = null!;

    [Column(TypeName = "enum('ACTIVO','INACTIVO')")]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdRepresentanteNavigation")]
    public virtual ICollection<BeneficiarioXRepresentante> BeneficiarioXRepresentantes { get; set; } = new List<BeneficiarioXRepresentante>();

    [InverseProperty("IdRepresentanteNavigation")]
    public virtual ICollection<ServicioVoluntariado> ServicioVoluntariados { get; set; } = new List<ServicioVoluntariado>();
}
