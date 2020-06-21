using Microsoft.AspNetCore.Mvc;
using Test2.Services;

namespace Test2.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    
    public class DoctorsController : ControllerBase
    {
        private readonly IDbService _context;
        
        public DoctorsController(IDbService context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.GetDoctors());
        }
    }
}