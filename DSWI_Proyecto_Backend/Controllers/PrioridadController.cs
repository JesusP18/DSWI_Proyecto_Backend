using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_Proyecto_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> obtenerPrioridades()
        {
            var lista = await Task.Run(() => new PrioridadDAO().obtenerPrioridades());
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerPrioridad(int id)
        {
            var prioridad = await Task.Run(() => new PrioridadDAO().obtenerPrioridadPorId(id));
            return Ok(prioridad);
        }

        [HttpPost]
        public async Task<IActionResult> registrarPrioridad(Prioridad prioridad)
        {
            var mensaje = await Task.Run(() => new PrioridadDAO().registrarPrioridad(prioridad));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarPrioridad(Prioridad prioridad)
        {
            var mensaje = await Task.Run(() => new PrioridadDAO().actualizarPrioridad(prioridad));
            return Ok(mensaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarPrioridad(int id)
        {
            var mensaje = await Task.Run(() => new PrioridadDAO().eliminarPrioridad(id));
            return Ok(mensaje);
        }
    }
}
