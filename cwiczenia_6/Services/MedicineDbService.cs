using cwiczenia_6.Context;
using cwiczenia_6.Models;
using cwiczenia_6.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia_6.Services;

public class MedicineDbService : IMedicineDbService
{
    private readonly MedicineDbContext _dbContext;

    public MedicineDbService(MedicineDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<DoctorInfo>> GetDoctors()
    {
        return await _dbContext.Doctors
            .Select(d => new DoctorInfo
            {
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email
            }).ToListAsync();
    }

    public async Task AddDoctor(DoctorInfo doctorInfo)
    {
        var doctor = new Doctor
        {
            FirstName = doctorInfo.FirstName,
            LastName = doctorInfo.LastName,
            Email = doctorInfo.Email
        };

        _dbContext.Add(doctor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EditDoctor(int id, DoctorInfoEdit doctorInfo)
    {
        var doctor = await _dbContext.Doctors.Where(d => d.IdDoctor == id).FirstOrDefaultAsync();

        if (doctor == null)
        {
            throw new BadHttpRequestException("Given doctor does not exists.", 400);
        }
        
        if (doctorInfo.FirstName != null)
            doctor.FirstName = doctorInfo.FirstName;
        if (doctorInfo.LastName != null)
            doctor.LastName = doctorInfo.LastName;
        if (doctorInfo.Email != null)
            doctor.Email = doctorInfo.Email;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDoctor(int id)
    {
        var doctor = await _dbContext.Doctors.Where(d => d.IdDoctor == id).FirstOrDefaultAsync();
        if (doctor == null)
        {
            throw new BadHttpRequestException("Given doctor does not exists.", 400);
        }

        _dbContext.Remove(doctor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PrescriptionInfo> GetPrescription(int id)
    {
        var prescription = await _dbContext.Prescriptions
            .Where(p => p.IdPrescription == id)
            .Select(p => new PrescriptionInfo
            {
                Date = p.Date,
                DueDate = p.DueDate,
                DoctorInfo = new DoctorInfo
                {
                    FirstName = p.Doctor.FirstName,
                    LastName = p.Doctor.LastName,
                    Email = p.Doctor.Email
                },
                PatientInfo = new PatientInfo
                {
                    FirstName = p.Patient.FirstName,
                    LastName = p.Patient.LastName,
                    Birthday = p.Patient.Birthdate
                },
                Medicaments = p.PrescriptionMedicaments.Select(pm => new MedicamentInfo
                {
                    Name = pm.Medicaments.Name,
                    Description = pm.Medicaments.Description,
                    Type = pm.Medicaments.Type
                }),
            })
            .FirstOrDefaultAsync();
        
        if (prescription == null)
        {
            throw new BadHttpRequestException("Given prescription does not exists.", 400);
        }

        return prescription;
    }
}