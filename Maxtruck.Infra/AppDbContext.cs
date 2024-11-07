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

        public DbSet<User> User { get; set; }

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



            });
        }


    }
}
