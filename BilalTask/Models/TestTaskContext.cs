using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BilalTask.Models
{
    public partial class TestTaskContext : DbContext
    {
        public TestTaskContext(DbContextOptions<TestTaskContext> options)
           : base(options)
        {
        }


        public virtual DbSet<BenefitsGrid> BenefitsGrids { get; set; }
        public virtual DbSet<BodyType> BodyTypes { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<CarTrim> CarTrims { get; set; }
        public virtual DbSet<Carmake> Carmakes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=testserverbilal.database.windows.net;Database=TestTask;user=bilal;password=Test@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BenefitsGrid>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BenefitsGrid");

                entity.Property(e => e.Agency)
                    .HasMaxLength(10)
                    .HasColumnName("agency");

                entity.Property(e => e.Benefit).HasColumnName("benefit");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Nonagency)
                    .HasMaxLength(10)
                    .HasColumnName("nonagency");

                entity.Property(e => e.Thirdparty)
                    .HasMaxLength(10)
                    .HasColumnName("thirdparty");
            });

            modelBuilder.Entity<BodyType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BodyType");

                entity.Property(e => e.TypeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TypeID");
            });

            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CarModel");

                entity.Property(e => e.ModelId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ModelID");

                entity.HasOne(d => d.Make)
                    .WithMany()
                    .HasForeignKey(d => d.MakeId)
                    .HasConstraintName("FK__CarModel__MakeId__5DCAEF64");
            });

            modelBuilder.Entity<CarTrim>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CarTrim");

                entity.Property(e => e.TrimId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Carmake>(entity =>
            {
                entity.HasKey(e => e.MakeId);

                entity.ToTable("Carmake");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
