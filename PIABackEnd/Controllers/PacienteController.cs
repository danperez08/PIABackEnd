using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIABackEnd.Entidades;


namespace PIABackEnd.Controllers
{

    [ApiController]
    [Route("api/paciente")]
    public class PacienteController :ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PacienteController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> Get()
        {
            return await dbContext.Pacientes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Paciente paciente)
        {
            dbContext.Add(paciente);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Paciente paciente, int id)
        {
            if (paciente.Id != id)
            {
                return BadRequest("El id del paciente no coincide con el establecido en la url");
            }
            dbContext.Update(paciente);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Pacientes.AnyAsync(x => x.Id == id);
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