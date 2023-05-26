using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIABackEnd.DTOs;
using PIABackEnd.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace PIABackEnd.Controllers
{

    [ApiController]
    [Route("api/cita")]
    public class CitaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<CitaController> logger;
        private readonly IMapper mapper;

        public CitaController(ApplicationDbContext context, ILogger<CitaController> logger, IMapper mapper)
        {
            this.dbContext = context;
            this.logger = logger;

            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]

        public async Task<ActionResult<List<Cita>>> Get()
        {
            logger.LogInformation("Se obtiene la lisat de las citas programadas");
            return await dbContext.Citas.ToListAsync();
        }

        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [Authorize(Roles = "admin")]

        public async Task<ActionResult<CitaDTO>> GetByID(int id)
            {
            var cita = await dbContext.Citas
                .Include(c => c.Doctor) // Incluir la entidad relacionada "Doctor"
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(c => c.Id == id);


            if (cita == null)
                {
                    return NotFound();
                }

                var citaDTO = mapper.Map<CitaDTO>(cita);

                return citaDTO;
            }

/*
        [HttpPost]
        public async Task<ActionResult> Post(Cita cita)
        {
            try
            {
                dbContext.Add(cita);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Hubo un error al crear una cita");
                
                return BadRequest("Ocurrio un error inesperado, vuelve a intentarlo xc");

            }

        }*/

        [HttpPost]
        [Produces("application/json")]
        [Authorize(Roles = "admin")]

        public async Task<ActionResult> CreateEvento(CrearCitaDTO crearcitadto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            var cita = mapper.Map<Cita>(crearcitadto);

            dbContext.Citas.Add(cita);
            await dbContext.SaveChangesAsync();

            var citadto = mapper.Map<CitaDTO>(cita);

            return CreatedAtAction(nameof(GetByID), new { id = citadto.Id }, citadto);

        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "admin")]

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
        [Authorize(Roles = "admin")]

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