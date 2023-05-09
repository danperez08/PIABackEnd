using Microsoft.AspNetCore.Mvc;
using PIABackEnd.Entidades;

namespace PIABackEnd.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Doctor>> Get()
        {
            return new List<Doctor>()
            {
                new Doctor() {Id = 1, Nombre = "Daniel"},
                new Doctor() {Id = 2, Nombre = "Alejandro"}
            };
        }
    }
}
