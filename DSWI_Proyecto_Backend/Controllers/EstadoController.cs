using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_Proyecto_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> obtenerEstados()
        {
            var lista = await Task.Run(() => new EstadoDAO().obtenerEstados());
            return Ok(lista);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerEstado(int id)
        {
            var estado = await Task.Run(() => new EstadoDAO().obtenerEstadoPorId(id));
            return Ok(estado);
        }

        [HttpPost]
        public async Task<IActionResult> registrarEstado(Estado estado)
        {
            var mensaje = await Task.Run(() => new EstadoDAO().registrarEstado(estado));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarEstado(Estado estado)
        {
            var mensaje = await Task.Run(() => new EstadoDAO().actualizarEstado(estado));
            return Ok(mensaje);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarEstado(int id)
        {
            var mensaje = await Task.Run(() => new EstadoDAO().eliminarEstado(id));
            return Ok(mensaje);
        }
    }
}
