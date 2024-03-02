using Microsoft.AspNetCore.Mvc;
using DeleteApi.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeleteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DeleteController(AppDbContext context)
        {
            _context = context;
        }

        // DELETE api/<DeleteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hospitalToRemove = _context.Hospitals.Find(id);
            if (hospitalToRemove == null)
                return NotFound();


            _context.Hospitals.Remove(hospitalToRemove);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
