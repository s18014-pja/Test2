using System;
using System.Collections.Generic;
using System.Linq;
using Test2.DTOs;
using Test2.Models;

namespace Test2.Services
{
    public class DoctorsContextDbService : IDbService
    {
        
        private DoctorsDbContext _context;
        public DoctorsContextDbService(DoctorsDbContext context)
        {
            _context = new DoctorsDbContext();
        }
        public IEnumerable<Doctor> GetDoctors()
        {
            _context = new DoctorsDbContext();
            return _context.Doctors.ToList();
        }

        public Doctor GetDoctor(int idDoctor)
        {
            _context = new DoctorsDbContext();
            Doctor doctor;
            try
            {
                doctor = _context.Doctors
                    .First(x => x.IdDoctor == idDoctor);
            }
            catch
            {
                return null;
            }
            return doctor;
        }

        public Doctor AddDoctor(AddDoctorRequest request)
        {
            _context = new DoctorsDbContext();
            var doctor = new Doctor {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public Doctor ChangeDoctorEmail(ChangeDoctorEmailRequest request)
        {
            _context = new DoctorsDbContext();
            var doctor = _context.Doctors.Where(x => x.FirstName == request.FirstName)
                .First(x => x.LastName == request.LastName);
            if (doctor == null)
                return null;
            doctor.Email = request.Email;
            _context.SaveChanges();
            return doctor;
        }

        public bool DeleteDoctor(DeleteDoctorRequest request)
        {
            _context = new DoctorsDbContext();
            var doctor = _context.Doctors.First(d => d.IdDoctor == Convert.ToInt32(request.IdDoctor));
            if (doctor == null)
                return false;
            _context.Remove(doctor);
            _context.SaveChanges();
            return true;
        }
    }
}