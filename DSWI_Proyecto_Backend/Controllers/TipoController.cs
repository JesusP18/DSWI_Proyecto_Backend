using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_Proyecto_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> obtenerTipos()
        {
            var lista = await Task.Run(() => new TipoDAO().obtenerTipos());
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerTipo(int id)
        {
            var tipo = await Task.Run(() => new TipoDAO().obtenerTipoPorId(id));
            return Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> registrarTipo(Tipo tipo)
        {
            var mensaje = await Task.Run(() => new TipoDAO().registrarTipo(tipo));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarTipo(Tipo tipo)
        {
            var mensaje = await Task.Run(() => new TipoDAO().actualizarTipo(tipo));
            return Ok(mensaje);
        }

        [HttpDelete]
        public async Task<IActionResult> eliminarTipo(int id)
        {
            var mensaje = await Task.Run(() => new TipoDAO().eliminarTipo(id));
            return Ok(mensaje);
        }
    }
}
