using System.ComponentModel.DataAnnotations;

namespace Test2.DTOs
{
    public class AddDoctorRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}