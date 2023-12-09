using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionEscolar.Models;

public partial class GestionEscolarContext : DbContext
{
    public GestionEscolarContext()
    {
    }

    public GestionEscolarContext(DbContextOptions<GestionEscolarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AlumnosMateria> AlumnosMaterias { get; set; }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-NHNT9S7U; Database=GestionEscolar; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alumnos__3214EC075FD3B2F8");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AlumnosMateria>(entity =>
        {
            entity.HasKey(e => new { e.IdAlumno, e.IdMateria }).HasName("PK__AlumnosM__04D91DC1F1FF6124");

            entity.Property(e => e.IdAlumno).HasColumnName("Id_alumno");
            entity.Property(e => e.IdMateria).HasColumnName("Id_materia");
            entity.Property(e => e.IdCalificacion).HasColumnName("Id_calificacion");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.AlumnosMateria)
                .HasForeignKey(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AlumnosMa__Id_al__4316F928");

            entity.HasOne(d => d.IdCalificacionNavigation).WithMany(p => p.AlumnosMateria)
                .HasForeignKey(d => d.IdCalificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AlumnosMa__Id_ca__44FF419A");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.AlumnosMateria)
                .HasForeignKey(d => d.IdMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AlumnosMa__Id_ma__440B1D61");
        });

        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Califica__3214EC079861C759");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Materias__3214EC07468728CD");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3214EC07183DEDB9");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasMany(d => d.IdAlumnos).WithMany(p => p.IdProfesors)
                .UsingEntity<Dictionary<string, object>>(
                    "AlumnosProfesore",
                    r => r.HasOne<Alumno>().WithMany()
                        .HasForeignKey("IdAlumno")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AlumnosPr__Id_al__4CA06362"),
                    l => l.HasOne<Profesore>().WithMany()
                        .HasForeignKey("IdProfesor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AlumnosPr__Id_pr__4BAC3F29"),
                    j =>
                    {
                        j.HasKey("IdProfesor", "IdAlumno").HasName("PK__AlumnosP__4FBFC5432340B465");
                    });

            entity.HasMany(d => d.IdMateria).WithMany(p => p.IdProfesors)
                .UsingEntity<Dictionary<string, object>>(
                    "MateriasProfesore",
                    r => r.HasOne<Materia>().WithMany()
                        .HasForeignKey("IdMateria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MateriasP__Id_ma__48CFD27E"),
                    l => l.HasOne<Profesore>().WithMany()
                        .HasForeignKey("IdProfesor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MateriasP__Id_pr__47DBAE45"),
                    j =>
                    {
                        j.HasKey("IdProfesor", "IdMateria").HasName("PK__Materias__4432EF675AFEA76F");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
