using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Proyecto_Resplandece.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beneficiario> Beneficiarios { get; set; }

    public virtual DbSet<BeneficiarioXRepresentante> BeneficiarioXRepresentantes { get; set; }

    public virtual DbSet<ContactosEmergencium> ContactosEmergencia { get; set; }

    public virtual DbSet<DetalleApoyoPatrocinador> DetalleApoyoPatrocinadors { get; set; }

    public virtual DbSet<DocumentoBeneficiario> DocumentoBeneficiarios { get; set; }

    public virtual DbSet<InformacionMedica> InformacionMedicas { get; set; }

    public virtual DbSet<Opcion> Opcions { get; set; }

    public virtual DbSet<PagoColegiatura> PagoColegiaturas { get; set; }

    public virtual DbSet<Patrocinador> Patrocinadors { get; set; }

    public virtual DbSet<Representante> Representantes { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolXOpcion> RolXOpcions { get; set; }

    public virtual DbSet<ServicioVoluntariado> ServicioVoluntariados { get; set; }

    public virtual DbSet<TipoApoyo> TipoApoyos { get; set; }

    public virtual DbSet<TransaccionPatrocinador> TransaccionPatrocinadors { get; set; }

    public virtual DbSet<Tutor> Tutors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioXRol> UsuarioXRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=bd_proyecto;uid=root;pwd=smilecry98", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.5.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Beneficiario>(entity =>
        {
            entity.HasKey(e => e.IdBeneficiarios).HasName("PRIMARY");

            entity.Property(e => e.Becado).HasDefaultValueSql("'0'");
            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.FechaModificacion).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.IdTutorNavigation).WithMany(p => p.Beneficiarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Beneficiario_Tutor");
        });

        modelBuilder.Entity<BeneficiarioXRepresentante>(entity =>
        {
            entity.HasKey(e => e.IdBR).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");
            entity.Property(e => e.FechaAsignacion).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.IdBeneficiarioNavigation).WithMany(p => p.BeneficiarioXRepresentantes).HasConstraintName("FK_BR_Beneficiario");

            entity.HasOne(d => d.IdRepresentanteNavigation).WithMany(p => p.BeneficiarioXRepresentantes).HasConstraintName("FK_BR_Representante");
        });

        modelBuilder.Entity<ContactosEmergencium>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");
            entity.Property(e => e.Prioridad).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.IdBeneficiarioNavigation).WithMany(p => p.ContactosEmergencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CE_Beneficiario");
        });

        modelBuilder.Entity<DetalleApoyoPatrocinador>(entity =>
        {
            entity.HasKey(e => e.IdDetalleApoyo).HasName("PRIMARY");

            entity.Property(e => e.Cantidad).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.IdTipoApoyoNavigation).WithMany(p => p.DetalleApoyoPatrocinadors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DAP_TipoApoyo");

            entity.HasOne(d => d.IdTransaccionNavigation).WithMany(p => p.DetalleApoyoPatrocinadors).HasConstraintName("FK_DAP_Transaccion");
        });

        modelBuilder.Entity<DocumentoBeneficiario>(entity =>
        {
            entity.HasKey(e => e.IdDocumento).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");
            entity.Property(e => e.FechaSubida).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.TipoDocumento).HasDefaultValueSql("'REPORTE_NOTAS'");

            entity.HasOne(d => d.IdBeneficiarioNavigation).WithMany(p => p.DocumentoBeneficiarios).HasConstraintName("FK_Doc_Beneficiario");
        });

        modelBuilder.Entity<InformacionMedica>(entity =>
        {
            entity.HasKey(e => e.IdBeneficiario).HasName("PRIMARY");

            entity.Property(e => e.IdBeneficiario).ValueGeneratedNever();
            entity.Property(e => e.FechaActualizacion).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.IdBeneficiarioNavigation).WithOne(p => p.InformacionMedica).HasConstraintName("FK_IM_Beneficiario");
        });

        modelBuilder.Entity<Opcion>(entity =>
        {
            entity.HasKey(e => e.IdOpcion).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.FechaModificacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<PagoColegiatura>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'PAGADO'");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.IdBeneficiarioNavigation).WithMany(p => p.PagoColegiaturas).HasConstraintName("FK_Pago_Beneficiario");
        });

        modelBuilder.Entity<Patrocinador>(entity =>
        {
            entity.HasKey(e => e.IdPatrocinador).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.TipoIdentificacion).HasDefaultValueSql("'CEDULA'");
        });

        modelBuilder.Entity<Representante>(entity =>
        {
            entity.HasKey(e => e.IdRepresentante).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.FechaModificacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<RolXOpcion>(entity =>
        {
            entity.HasKey(e => e.IdRolOpcion).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");
            entity.Property(e => e.Permitido).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.IdOpcionNavigation).WithMany(p => p.RolXOpcions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RXR_Opcion");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolXOpcions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RXR_Rol");
        });

        modelBuilder.Entity<ServicioVoluntariado>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PRIMARY");

            entity.Property(e => e.Asistencia).HasDefaultValueSql("'1'");
            entity.Property(e => e.Estado).HasDefaultValueSql("'COMPLETO'");
            entity.Property(e => e.TipoServicio).HasDefaultValueSql("'EVENTO'");

            entity.HasOne(d => d.IdRepresentanteNavigation).WithMany(p => p.ServicioVoluntariados).HasConstraintName("FK_SV_Representante");

            entity.HasOne(d => d.RegistradoPorNavigation).WithMany(p => p.ServicioVoluntariados).HasConstraintName("FK_SV_Usuario");
        });

        modelBuilder.Entity<TipoApoyo>(entity =>
        {
            entity.HasKey(e => e.IdTipoApoyo).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");
        });

        modelBuilder.Entity<TransaccionPatrocinador>(entity =>
        {
            entity.HasKey(e => e.IdTransaccion).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'COMPLETADA'");
            entity.Property(e => e.FechaTransaccion).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.TipoDonacion).HasDefaultValueSql("'EFECTIVO'");

            entity.HasOne(d => d.IdPatrocinadorNavigation).WithMany(p => p.TransaccionPatrocinadors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaccion_Patrocinador");
        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.HasKey(e => e.IdTutor).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.FechaModificacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.FechaModificacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<UsuarioXRol>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioRol).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'ACTIVO'");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UsuarioXRols).HasConstraintName("FK_UXR_Rol");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioXRols).HasConstraintName("FK_UXR_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
