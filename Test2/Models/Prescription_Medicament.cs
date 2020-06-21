using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
    public class Prescription_Medicament
    {
        [ForeignKey("Prescription")]
        public int IdPrescription { get; set; }

        [ForeignKey("Medicament")]
        public int IdMedicament { get; set; }

        public Prescription Prescription { get; set; }
        public Medicament Medicament { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
    }
}