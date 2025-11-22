using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Resplandece.Clases
{
    [Table("BENEFICIARIOS")]
    public class Beneficiarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("CEDULA")]
        public string Cedula { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("NOMBRES")]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("APELLIDOS")]
        public string Apellidos { get; set; }

        [MaxLength(200)]
        [Column("DIRECCION")]
        public string Direccion { get; set; }

        [Required]
        [Column("FECHA_NACIMIENTO")]
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(100)]
        [Column("PLANTEL_EDUCATIVO")]
        public string PlantelEducativo { get; set; }

        [MaxLength(50)]
        [Column("ANIO_EDUCATIVO")]
        public string AnioEducativo { get; set; }

        [MaxLength(15)]
        [Column("TELEFONO")]
        public string Telefono { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        [Column("EMAIL")]
        public string Email { get; set; }

        [Column("EDAD")]
        public int Edad { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("NOMBRES_COMPLETOS")]
        public string NombresCompletos { get; set; }
        [Required]
        [Column("FECHA_CREACION")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(1)]
        [Column("ESTADO")]
        public string Estado { get; set; } = "A";

        public Beneficiarios() { }

        public Beneficiarios(string cedulaBeneficiario, string nombresBeneficiario, string apellidosBeneficiario,
                         string direccion, DateTime fecha_nacimiento, string plantel_educativo,
                         string anio_educativo, string telefono, string emailBeneficiario)
        {
            this.Cedula = cedulaBeneficiario;
            this.Nombres = nombresBeneficiario;
            this.Apellidos = apellidosBeneficiario;
            this.Direccion = direccion;
            this.FechaNacimiento = fecha_nacimiento;
            this.PlantelEducativo = plantel_educativo;
            this.AnioEducativo = anio_educativo;
            this.Telefono = telefono;
            this.Email = emailBeneficiario;
            this.NombresCompletos = nombresBeneficiario + " " + apellidosBeneficiario;

            // Calcular edad
            this.Edad = DateTime.Now.Year - this.FechaNacimiento.Year;
            if (DateTime.Now.Month < this.FechaNacimiento.Month ||
                (DateTime.Now.Month == this.FechaNacimiento.Month && DateTime.Now.Day < this.FechaNacimiento.Day))
            {
                this.Edad--;
            }

            this.Codigo = "BE" + DateTime.Now.Ticks.ToString().Substring(10, 4);
        }
    }
}
