using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_Proyecto_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> obtenerProyectos()
        {
            var lista = await Task.Run(() => new ProyectoDAO().obtenerProyectos());
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerProyecto(int id)
        {
            var proyecto = await Task.Run(() => new ProyectoDAO().obtenerProyectoPorId(id));
            return Ok(proyecto);
        }

        [HttpPost]
        public async Task<IActionResult> registrarProyecto(ProyectoOriginal proyectoOriginal)
        {
            var mensaje = await Task.Run(() => new ProyectoDAO().registrarProyecto(proyectoOriginal));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarProyecto(ProyectoOriginal proyectoOriginal)
        {
            var mensaje = await Task.Run(() => new ProyectoDAO().actualizarProyecto(proyectoOriginal));
            return Ok(mensaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarProyecto(int id)
        {
            var mensaje = await Task.Run(() => new ProyectoDAO().eliminarProyecto(id));
            return Ok(mensaje);
        }

    }
}
