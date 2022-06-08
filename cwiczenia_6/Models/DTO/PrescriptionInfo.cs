namespace cwiczenia_6.Models.DTO;

public class PrescriptionInfo
{
    public PatientInfo PatientInfo { get; set; }
    public DoctorInfo DoctorInfo { get; set; }
    public IEnumerable<MedicamentInfo> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}