using cwiczenia_6.Models.DTO;

namespace cwiczenia_6.Services;

public interface IMedicineDbService
{
    Task<IEnumerable<DoctorInfo>> GetDoctors();
    Task AddDoctor(DoctorInfo doctorInfo);
    Task EditDoctor(int id, DoctorInfoEdit doctorInfo);
    Task DeleteDoctor(int id);
    Task<PrescriptionInfo> GetPrescription(int id);
}