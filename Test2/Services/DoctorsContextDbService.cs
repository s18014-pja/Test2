using System.Collections.Generic;
using System.Linq;
using Test2.Models;

namespace Test2.Services
{
    public class DoctorsContextDbService : IDbService
    {
        
        private readonly DoctorsDbContext _context;
        public DoctorsContextDbService(DoctorsDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }
    }
}