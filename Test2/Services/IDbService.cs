using System.Collections.Generic;
using Test2.DTOs;
using Test2.Models;

namespace Test2.Services
{
    public interface IDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public Doctor GetDoctor(int idDoctor);
        public Doctor AddDoctor(AddDoctorRequest request);
        public Doctor ChangeDoctorEmail(ChangeDoctorEmailRequest request);
        public bool DeleteDoctor(DeleteDoctorRequest request);
    }
}