using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIABackEnd.Entidades;

namespace PIABackEnd.Controllers
{

    [ApiController]
    [Route("api/cita")]
    public class CitaController :ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CitaController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cita>>> Get()
        {
            return await dbContext.Citas.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult> Post(Cita cita)
        {
            dbContext.Add(cita);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Cita cita, int id)
        {
            if (cita.Id != id)
            {
                return BadRequest("El id de la cita no coincide con el establecido en la url");
            }
            dbContext.Update(cita);
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

            dbContext.Remove(new Cita()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}