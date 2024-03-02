using Microsoft.AspNetCore.Mvc;
using CreateApi.Data;
using CreateApi.Models;
using Microsoft.AspNetCore.Cors;

namespace CreateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CreateController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CreateController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var hospital = _context.Hospitals.Find(id);
            if (hospital == null)
                return NotFound();


            return Ok(hospital);
        }

        // POST api/<CreateController>
        [HttpPost]
        public IActionResult Create([FromBody] Model hospital)
        {
            _context.Hospitals.Add(hospital);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = hospital.Id }, hospital);
        }

    }
}
