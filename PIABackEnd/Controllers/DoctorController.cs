using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIABackEnd.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data;


namespace PIABackEnd.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;
        public DoctorController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<Doctor>>> Get()
        {
            return await dbContext.Doctors.ToListAsync();
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult> Post(Doctor doctor)
        {
            /* dbContext.Add(doctor);
             await dbContext.SaveChangesAsync();
             return Ok();*/
            // Verificar si el usuario ya existe
            var userExist = await userManager.FindByNameAsync(doctor.UserName);
            if (userExist != null)
            {
                return BadRequest("El usuario ya existe");
            }

            // Crear el usuario y asignar el rol de administrador
            var user = new IdentityUser
            {
                UserName = doctor.UserName,
                Email = doctor.Email
            };
            var result = await userManager.CreateAsync(user, doctor.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "admin"); // Asignar el rol de administrador
            }
            else
            {
                return BadRequest(result.Errors);
            }

            // Guardar el doctor en la base de datos
            dbContext.Add(doctor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    

        [HttpPut("{id:int}")]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
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