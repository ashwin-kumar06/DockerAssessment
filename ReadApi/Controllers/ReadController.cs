using Microsoft.AspNetCore.Mvc;
using ReadApi.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System;

namespace ReadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ReadController(AppDbContext context)
        {
            _context = context;
        }

        // DELETE api/<DeleteController>/5
        [HttpGet]
        public IActionResult Get()
        {
            var hospitals = _context.Hospitals.ToList();
            return Ok(hospitals);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var patient = _context.Hospitals.Find(id);
            if (patient == null)
                return NotFound();


            return Ok(patient);
        }
    }
}
