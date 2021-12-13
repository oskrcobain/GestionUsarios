using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GestionUsarios.Models;

namespace GestionUsarios.Models
{
    public partial class BDS_SysGestContext : DbContext
    {
        public BDS_SysGestContext()
        {
        }

        public BDS_SysGestContext(DbContextOptions<BDS_SysGestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAlumno> TblAlumnos { get; set; } = null!;
        public virtual DbSet<TblMateriaHasAlumno> TblMateriaHasAlumnos { get; set; } = null!;
        public virtual DbSet<TblMaterium> TblMateria { get; set; } = null!;
        public virtual DbSet<TblProfesor> TblProfesors { get; set; } = null!;
        public virtual DbSet<TblPrograma> TblProgramas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=DESKTOP-DLNU13N; Initial Catalog=BDS_SysGest; user id=sa; password=raat;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAlumno>(entity =>
            {
                entity.HasKey(e => e.PkAlmIdAlumno)
                    .HasName("PK__TBL_Alum__50879DB57A3C375D");

                entity.ToTable("TBL_Alumno");

                entity.Property(e => e.PkAlmIdAlumno).HasColumnName("PK_ALM_IdAlumno");

                entity.Property(e => e.AlmApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALM_Apellido");

                entity.Property(e => e.AlmCreditos).HasColumnName("ALM_Creditos");

                entity.Property(e => e.AlmNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALM_Nombre");
            });

            modelBuilder.Entity<TblMateriaHasAlumno>(entity =>
            {
                entity.HasKey(e => e.PkAlmHasMtrIdAlumnoHasMateria)
                    .HasName("PK__TBL_Mate__0496257F17FE1DC3");

                entity.ToTable("TBL_Materia_Has_Alumno");

                entity.Property(e => e.PkAlmHasMtrIdAlumnoHasMateria).HasColumnName("PK_MHA_IdMHA");

                entity.Property(e => e.FkAlmIdAlumno).HasColumnName("FK_ALM_IdAlumno");

                entity.Property(e => e.FkMtrIdMateria).HasColumnName("FK_MTR_IdMateria");

                entity.HasOne(d => d.FkAlmIdAlumnoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkAlmIdAlumno)
                    .HasConstraintName("FK__TBL_Mater__FK_AL__3A81B327");

                entity.HasOne(d => d.FkMtrIdMateriaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkMtrIdMateria)
                    .HasConstraintName("FK__TBL_Mater__FK_MT__3C69FB99");
            });

            modelBuilder.Entity<TblMaterium>(entity =>
            {
                entity.HasKey(e => e.PkMtrIdMateria)
                    .HasName("PK__TBL_Mate__882DF69CF4DB6E3D");

                entity.ToTable("TBL_Materia");

                entity.Property(e => e.PkMtrIdMateria).HasColumnName("PK_MTR_IdMateria");

                entity.Property(e => e.FkPgmIdPrograma).HasColumnName("FK_PGM_IdPrograma");

                entity.Property(e => e.MtrCurso)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MTR_Curso");

                entity.Property(e => e.MtrModulo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MTR_Modulo");

                entity.Property(e => e.MtrNombre)
                    .HasMaxLength(50)
                    .HasColumnName("MTR_Nombre");

                entity.HasOne(d => d.FkPgmIdProgramaNavigation)
                    .WithMany(p => p.TblMateria)
                    .HasForeignKey(d => d.FkPgmIdPrograma)
                    .HasConstraintName("FK__TBL_Mater__FK_PG__33D4B598");
            });

            modelBuilder.Entity<TblProfesor>(entity =>
            {
                entity.HasKey(e => e.PkPfsIdProfesor)
                    .HasName("PK__TBL_Prof__9F7D271346109F2E");

                entity.ToTable("TBL_Profesor");

                entity.Property(e => e.PkPfsIdProfesor).HasColumnName("PK_PFS_IdProfesor");

                entity.Property(e => e.FkPgmIdPrograma).HasColumnName("FK_PGM_IdPrograma");

                entity.Property(e => e.PfsApellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PFS_Apellidos");

                entity.Property(e => e.PfsCargo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PFS_Cargo");

                entity.Property(e => e.PfsEspecialidad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PFS_Especialidad");

                entity.Property(e => e.PfsNombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PFS_Nombres");

                entity.HasOne(d => d.FkPgmIdProgramaNavigation)
                    .WithMany(p => p.TblProfesors)
                    .HasForeignKey(d => d.FkPgmIdPrograma)
                    .HasConstraintName("FK__TBL_Profe__FK_PG__267ABA7A");
            });

            modelBuilder.Entity<TblPrograma>(entity =>
            {
                entity.HasKey(e => e.PkPgmIdPrograma)
                    .HasName("PK__TBL_Prog__4C00F103ED4BA690");

                entity.ToTable("TBL_Programa");

                entity.Property(e => e.PkPgmIdPrograma).HasColumnName("PK_PGM_IdPrograma");

                entity.Property(e => e.PgmAula)
                    .HasMaxLength(50)
                    .HasColumnName("PGM_Aula");

                entity.Property(e => e.PgmCosto).HasColumnName("PGM_Costo");

                entity.Property(e => e.PgmDuracion).HasColumnName("PGM_Duracion");

                entity.Property(e => e.PgmNombre)
                    .HasMaxLength(50)
                    .HasColumnName("PGM_Nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<GestionUsarios.Models.TblAlumno> Alumno { get; set; }

        public DbSet<GestionUsarios.Models.TblMaterium> Materia { get; set; }

        public DbSet<GestionUsarios.Models.TblMateriaHasAlumno> MateriaHasAlumno { get; set; }

        public DbSet<GestionUsarios.Models.TblProfesor> Profesor { get; set; }
    }
}
