﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIABackEnd.Entidades;

namespace PIABackEnd.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public DoctorController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> Get()
        {
            return await dbContext.Doctors.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Doctor doctor)
        {
            dbContext.Add(doctor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Doctor doctor, int id)
        {
            if (doctor.Id != id)
            {
                return BadRequest("El id del Doctor no coincide con el establecido en la url");
            }
            dbContext.Update(doctor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Doctors.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            dbContext.Remove(new Doctor()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
