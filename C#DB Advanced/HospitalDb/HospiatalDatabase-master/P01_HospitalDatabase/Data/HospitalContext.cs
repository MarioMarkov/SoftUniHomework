using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options): 
            base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionStrng);
            }
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurePatientEntity(modelBuilder);

            ConfigureVisitationEntity(modelBuilder);

            ConfigureDiagnoseEntity(modelBuilder);

            ConfigureMedicamentEntity(modelBuilder);
              
            ConfigurePatientMedicamentEntity(modelBuilder);

            ConfigureDoctorEntity(modelBuilder);
        }

        private void ConfigureDoctorEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                 .HasKey(x => x.DoctorId);

            modelBuilder.Entity<Doctor>()
                .HasMany(x => x.Visitations)
                .WithOne(x => x.Doctor);
        }

        private void ConfigurePatientMedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>()
                .HasKey(x => new
                {
                    x.MedicamentId,
                    x.PatientId
                });

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(pm => pm.Patient)
                .WithMany(x => x.Prescriptions)
                .HasForeignKey(pm => pm.PatientId);

            modelBuilder.Entity<PatientMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(x => x.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId);
        }

        private void ConfigureMedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>()
                .HasKey(x => x.MedicamentId);

            modelBuilder.Entity<Medicament>()
            .Property(x => x.Name)
            .HasMaxLength(50)
            .IsUnicode()
            .IsRequired();
        }

        private void ConfigureDiagnoseEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>()
                .HasKey(x => x.DiagnoseId);

            modelBuilder.Entity<Diagnose>()
              .Property(x => x.Name)
              .HasMaxLength(50)
              .IsUnicode()
              .IsRequired();

            modelBuilder.Entity<Diagnose>()
              .Property(x => x.Comments)
              .HasMaxLength(250)
              .IsUnicode();
        }

        private void ConfigureVisitationEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitation>()
                .HasKey(v => v.VisitationId);

            modelBuilder.Entity<Visitation>()
               .Property(x=> x.Comments)
               .HasMaxLength(250)
               .IsUnicode();

            modelBuilder.Entity<Visitation>()
               .HasOne(x=> x.Patient);
        }

        private void ConfigurePatientEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
               .HasKey(x => x.PatientId);

            modelBuilder.Entity<Patient>()
            .HasMany(x => x.Diagnoses)
            .WithOne(x => x.Patient);


            modelBuilder.Entity<Patient>()
           .HasMany(x => x.Visitations)
           .WithOne(x => x.Patient);

            modelBuilder.Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();
            modelBuilder.Entity<Patient>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();
            
            modelBuilder.Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.Email)
                .HasMaxLength(80);
        }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

    }
}
