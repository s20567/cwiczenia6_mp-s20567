using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cwiczenia_6.Models;

public class Prescription
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPrescription { get; set; }

    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }

    public int IdPatient { get; set; }
    
    public int IdDoctor { get; set; }

    [ForeignKey("IdDoctor")]
    public Doctor Doctor { get; set; }
    
    [ForeignKey("IdPatient")]
    public Patient Patient { get; set; }
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}