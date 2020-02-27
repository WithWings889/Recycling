using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab1ISTP
{
    public partial class RecyclingContext : DbContext
    {
        public RecyclingContext()
        {
        }

        public RecyclingContext(DbContextOptions<RecyclingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Garbage> Garbage { get; set; }
        public virtual DbSet<GarbageFactory> GarbageFactory { get; set; }
        public virtual DbSet<GarbageMaterial> GarbageMaterial { get; set; }
        public virtual DbSet<GarbageType> GarbageType { get; set; }
        public virtual DbSet<GarbageTypeFactory> GarbageTypeFactory { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialGarbage> MaterialGarbage { get; set; }
        public virtual DbSet<MaterialGarbageType> MaterialGarbageType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-P4TOSEA; Database=Recycling; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Garbage>(entity =>
            {
                entity.Property(e => e.Info).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GarbageFactory>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GarbageMaterial>(entity =>
            {
                entity.ToTable("Garbage_Material");

                entity.HasOne(d => d.IdGarbageNavigation)
                    .WithMany(p => p.GarbageMaterial)
                    .HasForeignKey(d => d.IdGarbage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Garbage_Material_Garbage");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.GarbageMaterial)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Garbage_Material_Material");
            });

            modelBuilder.Entity<GarbageType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GarbageTypeFactory>(entity =>
            {
                entity.ToTable("GarbageType_Factory");

                entity.HasOne(d => d.IdFactoryNavigation)
                    .WithMany(p => p.GarbageTypeFactory)
                    .HasForeignKey(d => d.IdFactory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GarbageType_Factory_Factory");

                entity.HasOne(d => d.IdGarbageTypeNavigation)
                    .WithMany(p => p.GarbageTypeFactory)
                    .HasForeignKey(d => d.IdGarbageType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GarbageType_Factory_GarbageType");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.Info).HasMaxLength(50);

                entity.Property(e => e.MaterialCard)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PricePerKilogram).HasColumnType("money");
            });

            modelBuilder.Entity<MaterialGarbage>(entity =>
            {
                entity.ToTable("Material_Garbage");

                entity.HasOne(d => d.IdGarbageNavigation)
                    .WithMany(p => p.MaterialGarbage)
                    .HasForeignKey(d => d.IdGarbage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Material_Garbage_Garbage");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.InverseIdMaterialNavigation)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Material_Garbage_Material");
            });

            modelBuilder.Entity<MaterialGarbageType>(entity =>
            {
                entity.ToTable("Material_GarbageType");

                entity.HasOne(d => d.IdGarbageTypeNavigation)
                    .WithMany(p => p.MaterialGarbageType)
                    .HasForeignKey(d => d.IdGarbageType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Material_GarbageType_GarbageType");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.MaterialGarbageType)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Material_GarbageType_Material");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
