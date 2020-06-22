using System.ComponentModel.DataAnnotations;

namespace Test2.DTOs
{
    public class DeleteDoctorRequest
    {
        [Required]
        public int IdDoctor { get; set; }
    }
}