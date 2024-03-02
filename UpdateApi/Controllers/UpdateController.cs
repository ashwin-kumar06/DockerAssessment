using Microsoft.AspNetCore.Mvc;
using UpdateApi.Data;
using UpdateApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.JsonPatch;

namespace UpdateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UpdateController(AppDbContext context)
        {
            _context = context;
        }

        // DELETE api/<DeleteController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Model updatedHospital)
        {
            var existingHospital = _context.Hospitals.Find(id);
            if (existingHospital == null)
                return NotFound();


            existingHospital.HospitalName = updatedHospital.HospitalName;
            // existingHospital.Age = updatedHospital.Age;
            // existingHospital.Email = updatedHospital.Email;
            // existingHospital.BloodGroup = updatedHospital.BloodGroup;
            // existingHospital.Location = updatedHospital.Location;
            // Update other properties


            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdate(int id, [FromBody] JsonPatchDocument<Model> patchDoc)
        {
            if (patchDoc == null || id <= 0)
            {
                BadRequest();
            }
            var existingHospital = _context.Hospitals.Where(s => s.Id == id).FirstOrDefault();
            if (existingHospital == null)
            {
                return NotFound();
            }
            var hos = new Model
            {
                Id = existingHospital.Id,
                HospitalName = existingHospital.HospitalName,
                // Age = existingHospital.Age,
                // Email = existingHospital.Email,
                // BloodGroup = existingHospital.BloodGroup,
                // Location = existingHospital.Location,
            };

            if (patchDoc != null)
            {
                patchDoc.ApplyTo(hos, ModelState);
            }

            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            existingHospital.HospitalName = hos.HospitalName;
            // existingHospital.Age = hos.Age;
            // existingHospital.Email = hos.Email;
            // existingHospital.BloodGroup = hos.BloodGroup;
            // existingHospital.Location = hos.Location;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
