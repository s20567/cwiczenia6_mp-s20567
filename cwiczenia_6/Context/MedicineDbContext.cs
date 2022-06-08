using cwiczenia_6.Models;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia_6.Context;

public class MedicineDbContext : DbContext
{
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    // public MedicineDbContext() {}
    public MedicineDbContext(DbContextOptions options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(d =>
        {
            d.HasData(
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Email = "jan.kowalski@gmail.com"
                },
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Ala",
                    LastName = "Kot",
                    Email = "alakot@op.pl"
                }
            );
        });

        modelBuilder.Entity<Patient>(p =>
        {
            p.HasData(
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "Ola",
                    LastName = "Nowak",
                    Birthdate = DateTime.Now
                }
            );
        });

        modelBuilder.Entity<Medicament>(m =>
        {
            m.HasData(
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "Paracetamol",
                    Description = "Lek przeciwbólowy",
                    Type = "Tabletka"
                },
                new Medicament
                {
                    IdMedicament = 2,
                    Name = "Ibuprofen",
                    Description = "Lek przeciwbólowy i przeciwgorączkowy",
                    Type = "Syrop"
                }
                );
        });

        modelBuilder.Entity<Prescription>(p =>
        {
            p.HasData(
                new Prescription
                {
                    IdPrescription = 1,
                    Date = DateTime.Now,
                    DueDate = DateTime.Now.AddMonths(9),
                    IdPatient = 1,
                    IdDoctor = 2
                }
            );
        });
        
        modelBuilder.Entity<PrescriptionMedicament>(pm =>
        {
            pm.HasKey(p => new { p.IdMedicament, p.IdPrescription });

            pm.HasData(
                new PrescriptionMedicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 2,
                    Details = "per day"
                },
                new PrescriptionMedicament
                {
                    IdMedicament = 2,
                    IdPrescription = 1,
                    Dose = 1,
                    Details = "per week"
                }
            );
        });
        
        base.OnModelCreating(modelBuilder);
    }
}