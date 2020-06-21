using System.Collections.Generic;
using Test2.Models;

namespace Test2.Services
{
    public interface IDbService
    {
        public IEnumerable<Doctor> GetDoctors();
    }
}