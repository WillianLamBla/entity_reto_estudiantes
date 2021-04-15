using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace baseDEntity.Modelo
{
    public partial class tallersenaContext : DbContext
    {
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost; userid=root; password=Will@19942521; Database=tallersena");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("estudiantes");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45);

                entity.Property(e => e.Nota1).HasColumnName("nota1");

                entity.Property(e => e.Nota2).HasColumnName("nota2");

                entity.Property(e => e.Nota3).HasColumnName("nota3");
            });
        }
    }
}
