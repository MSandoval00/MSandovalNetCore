using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class MsandovalNetCoreContext : DbContext
{
    public MsandovalNetCoreContext()
    {
    }

    public MsandovalNetCoreContext(DbContextOptions<MsandovalNetCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<RecetasMedica> RecetasMedicas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-G7UVJH5; Database= MSandovalNetCore; TrustServerCertificate=True;Trusted_Connection=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__C93DB49BCF62AF8B");

            entity.ToTable("Paciente");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RecetasMedica>(entity =>
        {
            entity.HasKey(e => e.IdReceta).HasName("PK__RecetasM__2CEFF157A668F5A7");

            entity.Property(e => e.Diagnostico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaConsulta).HasColumnType("datetime");
            entity.Property(e => e.NombreMedico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NotasAdicionales)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.RecetasMedicas)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__RecetasMe__IdPac__20C1E124");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
