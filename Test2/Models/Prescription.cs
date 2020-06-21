using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public Patient IdPatient { get; set; }
        public Doctor IdDoctor { get; set; }
        public virtual ICollection<Prescription_Medicament> Prescriptions_Medicaments { get; set; }
    }
}