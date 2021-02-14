using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin_APBD.Models
{
    public class MedicamentsDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        public MedicamentsDbContext() { }

        public MedicamentsDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prescription_Medicament>().HasKey(k => new
            {
                k.IdMedicament,
                k.IdPrescription
            });

            modelBuilder.Entity<Prescription_Medicament>()
              .HasOne(f => f.Prescription)
              .WithMany(f => f.Prescription_Medicaments)
              .HasForeignKey(f => f.IdPrescription);

            modelBuilder.Entity<Prescription_Medicament>()
             .HasOne(f => f.Medicament)
             .WithMany(f => f.Prescription_Medicaments)
             .HasForeignKey(f => f.IdMedicament);

            

            var doctors = new List<Doctor>();
            doctors.Add(new Doctor { IdDoctor = 1, FirstName = "Marcin ", LastName = "Chojancki", Email = "marcin@gmail.com" });
            doctors.Add(new Doctor { IdDoctor = 2, FirstName = "Lukasz", LastName = "Kujawa", Email = "luk@gmail.com" });
            doctors.Add(new Doctor { IdDoctor = 3, FirstName = "Piotr", LastName = "Krolikowski", Email = "piotr@gmail.com" });
            modelBuilder.Entity<Doctor>().HasData(doctors);

            var patients = new List<Patient>();
            patients.Add(new Patient { IdPatient = 1, FirstName = "Arek", LastName = "Polanski", Birthdate = new DateTime(1984, 3, 1) });
            patients.Add(new Patient { IdPatient = 2, FirstName = "Michal", LastName = "Jackiewicz", Birthdate = new DateTime(1981, 11, 12) });
            patients.Add(new Patient { IdPatient = 3, FirstName = "Tymoteusz", LastName = "Kielczewski", Birthdate = new DateTime(1993, 5, 11) });
            modelBuilder.Entity<Patient>().HasData(patients);

            var prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription { IdPrescription = 1, Date = new DateTime(2010, 1, 21), DueDate = new DateTime(2021, 1, 1), IdDoctor = 2, IdPatient = 2 });
            prescriptions.Add(new Prescription { IdPrescription = 2, Date = new DateTime(2010, 1, 21), DueDate = new DateTime(2021, 1, 1), IdDoctor = 1, IdPatient = 3 });
            prescriptions.Add(new Prescription { IdPrescription = 3, Date = new DateTime(2010, 1, 21), DueDate = new DateTime(2021, 1, 1), IdDoctor = 3, IdPatient = 1 });
            modelBuilder.Entity<Prescription>().HasData(prescriptions);

            var medicaments = new List<Medicament>();
            medicaments.Add(new Medicament { IdMedicament = 1, Name = "Rutinoscorbin", Description = "Na odporność", Type = "lek" });
            medicaments.Add(new Medicament { IdMedicament = 2, Name = "Duomox", Description = "Antybiotyk", Type = "lek" });
            medicaments.Add(new Medicament { IdMedicament = 3, Name = "Groprinosin", Description = "Walka z wirusami", Type = "lek" });
            modelBuilder.Entity<Medicament>().HasData(medicaments);

            var prescriptionsMedicament = new List<Prescription_Medicament>();
            prescriptionsMedicament.Add(new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "informacje" });
            prescriptionsMedicament.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 1, Dose = 2, Details = "szczegóły" });
            prescriptionsMedicament.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 3, Dose = 3, Details = "detale" });
            modelBuilder.Entity<Prescription_Medicament>().HasData(prescriptionsMedicament);

        }
    }
}
