using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_Proyecto_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> obtenerTareas()
        {
            var lista = await Task.Run(() => new TareaDAO().obtenerTareas());
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerTarea(int id)
        {
            var tarea = await Task.Run(() => new TareaDAO().obtenerTareaPorId(id));
            return Ok(tarea);
        }

        [HttpPost]
        public async Task<IActionResult> registrarTarea(Tarea tarea)
        {
            var mensaje = await Task.Run(() => new TareaDAO().registrarTarea(tarea));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarTarea(Tarea tarea)
        {
            var mensaje = await Task.Run(() => new TareaDAO().actualizarTarea(tarea));
            return Ok(mensaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarTarea(int id)
        {
            var mensaje = await Task.Run(() => new TareaDAO().eliminarTarea(id));
            return Ok(mensaje);
        }
    }
}
