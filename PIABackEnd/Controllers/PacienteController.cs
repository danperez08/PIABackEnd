using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIABackEnd.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using PIABackEnd.Entidades;
using AutoMapper;


namespace PIABackEnd.Controllers
{

    [ApiController]
    [Route("api/paciente")]
    public class PacienteController :ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;


        public PacienteController(ApplicationDbContext context, IMapper mapper)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> Get()
        {
            return await dbContext.Pacientes.ToListAsync();
        }


        [HttpGet("{id:int}")]
        [Produces("application/json")]
       
       public async Task<ActionResult<PacienteDTO>> GetByID(int id)
            {
                var paciente = await dbContext.Pacientes.FindAsync(id);

                if (paciente == null)
                {
                    return NotFound();
                }

                var pacienteDTO = mapper.Map<PacienteDTO>(paciente);

                return pacienteDTO;
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

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<PacientePatchDTO> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }
            var paciente = await dbContext.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            var pacientepatchDto = mapper.Map<PacientePatchDTO>(paciente);
            patchDocument.ApplyTo(pacientepatchDto, ModelState);

            if (!TryValidateModel(pacientepatchDto))
            {
                return BadRequest(ModelState);
            }

            mapper.Map(pacientepatchDto, paciente);
            await dbContext.SaveChangesAsync();

            return NoContent();

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