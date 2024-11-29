using Maxtruck.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {        
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Bridge> Bridges { get; set; }

        public DbSet<Truck> Trucks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("TB_USER");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar")
                    .IsRequired();

                entity.Property(e => e.Document)
                    .HasColumnName("document")
                    .HasColumnType("varchar")
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar")
                    .IsRequired();

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar")
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("create_at")
                    .HasColumnType("timestamp")
                    .IsRequired();

                entity.HasMany(u => u.Trucks);
            });

            modelBuilder.Entity<Truck>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .IsRequired();

                entity
                .HasOne(t => t.User)
                .WithMany(u => u.Trucks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.ToTable("TB_TRUCKS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasColumnType("varchar")
                    .IsRequired();

                entity.Property(e => e.Brand)
                    .HasColumnName("brand")
                    .HasColumnType("varchar")
                    .IsRequired();

                entity.Property(e => e.Lenght)
                    .HasColumnName("length")
                    .HasColumnType("numeric")
                    .IsRequired();

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("numeric")
                    .IsRequired();

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("numeric")
                    .IsRequired();

                entity.Property(e => e.LicensePlate)
                    .HasColumnName("license_plate")
                    .HasColumnType("varchar")
                    .IsRequired();

                entity.Property(e => e.LoadCapacity)
                    .HasColumnName("load_capacity")
                    .HasColumnType("numeric")
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("boolean")
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("create_at")
                    .HasColumnType("timestamp")
                    .IsRequired();

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Bridge>(entity =>
            {
                entity.ToTable("TB_BRIDGES");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar")
                    .IsRequired();

                entity.Property(e => e.MaxHeightCentral)
                    .HasColumnName("max_height_central")
                    .HasColumnType("numeric");

                entity.Property(e => e.MaxHeightExpressway)
                    .HasColumnName("max_height_expressway")
                    .HasColumnType("numeric");

                entity.Property(e => e.MaxHeightLocalRoad)
                    .HasColumnName("max_height_local_road")
                    .HasColumnType("numeric");

                entity.Property(e => e.MaxHeightSingleRoad)
                    .HasColumnName("max_height_single_road")
                    .HasColumnType("numeric");
            });
        }


    }
}
