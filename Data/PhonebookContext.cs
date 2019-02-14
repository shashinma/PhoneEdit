using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PhoneEdit.Models;

namespace PhoneEdit.Data
{
    public partial class PhonebookContext : DbContext
    {
        public PhonebookContext()
        {
        }

        public PhonebookContext(DbContextOptions<PhonebookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookEntry> Entries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntry>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("tel1");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("n")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Room)
                    .IsRequired()
                    .HasColumnName("komnata")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.PersonnelNumber)
                    .IsRequired()
                    .HasColumnName("tabNumber")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CityPhoneNumber)
                    .IsRequired()
                    .HasColumnName("telg")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LocalPhoneNumber)
                    .IsRequired()
                    .HasColumnName("telm")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("who")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasColumnName("work")
                    .HasColumnType("varchar(250)");
            });
        }
    }
}
