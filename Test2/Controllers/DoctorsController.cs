using Microsoft.AspNetCore.Mvc;
using Test2.DTOs;
using Test2.Models;
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
        
        [HttpGet("{idDoctor}")]
        public IActionResult GetDoctors(int idDoctor)
        {
            var response = _context.GetDoctor(idDoctor);
            return response == null ? Ok(BadRequest("Błędny parametr")) : Ok(response);
        }
        
        [HttpDelete]
        public IActionResult DeleteDoctor(DeleteDoctorRequest request)
        {
            var response = _context.DeleteDoctor(request);
            return response ? Ok("Usunięto doktora") : Ok(BadRequest("Błędne id doktora"));
        }

        [HttpPut]
        public IActionResult ChangeDoctorEmail(ChangeDoctorEmailRequest request)
        {
            var response = _context.ChangeDoctorEmail(request);
            return response == null ? Ok(BadRequest("Brak podanego doktora")) : Ok(response);
        }

        [HttpPost]
        public IActionResult AddDoctor(AddDoctorRequest request)
        {
            var response = _context.AddDoctor(request);
            return Created("Utworzono doktora", response);
        }
    }
}