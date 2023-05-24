using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIABackEnd.Entidades;

namespace PIABackEnd.Controllers
{
    [ApiController]
    [Route("api/registro_medico")]
    public class Registro_MedicoController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public Registro_MedicoController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Registro_Medico>>> Get()
        {
            return await dbContext.Registro_Medicos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Registro_Medico registro_medico)
        {
            dbContext.Add(registro_medico);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Registro_Medico registro_medico, int id)
        {
            if (registro_medico.PacienteId != id)
            {
                return BadRequest("El id del Doctor no coincide con el establecido en la url");
            }
            dbContext.Update(registro_medico);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Registro_Medicos.AnyAsync(x => x.PacienteId == id);
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