using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test2.Models
{
    public class DoctorsDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription_Medicament> Prescriptions_Medicaments { get; set; }
        
        public DoctorsDbContext()
        {
        }

        public DoctorsDbContext(DbContextOptions options): base(options)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=test;User Id=SA;Password=Trelek_123;");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Prescription_Medicament>()
                .HasKey(k => new { k.IdPrescription, k.IdMedicament });

            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                entity.Property(e => e.Dose)
                    .IsRequired(false);
                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.BirthDate).HasColumnType("date");
            });
            
            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.DueDate).HasColumnType("date");
            });
            
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Hieronim",
                    LastName = "Naczelny",
                    Email = "HieronimNaczelny@gmail.com"
                },
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Zdzisław",
                    LastName = "Konieczny",
                    Email = "ZdzislawKonieczny@gmail.com"
                }
            };
            modelBuilder.Entity<Doctor>()
                .HasData(doctors);
        }
    }
}