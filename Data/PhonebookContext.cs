using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PhoneEdit.Models;

namespace PhoneEdit.Data
{
    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
        {
        }

        public PhonebookContext(DbContextOptions<PhonebookContext> options)
            : base(options)
        {
        }

        public DbSet<BookEntry> Entries { get; set; }

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
                    .HasColumnType("integer");

                entity.Property(e => e.Room)
                    .HasColumnName("komnata")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Mail)
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
                    .HasColumnName("telg")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LocalPhoneNumber)
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