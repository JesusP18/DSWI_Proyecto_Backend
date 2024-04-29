using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_Proyecto_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplejidadController : ControllerBase
    {
        //OBTENER COMPLEJIDADES
        [HttpGet]
        public async Task<IActionResult> obtenerComplejidades()
        {
            var lista = await Task.Run(() => new ComplejidadDAO().obtenerComplejidades());
            return Ok(lista);
        }

        //OBTENER COMPLEJIDAD POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerComplejidad(int id)
        {
            var complejidad = await Task.Run(() => new ComplejidadDAO().obtenerComplejidadPorId(id));
            return Ok(complejidad);
        }

        //REGISTRAR COMPLEJIDAD
        [HttpPost]
        public async Task<IActionResult> registrarComplejidad(Complejidad complejidad)
        {
            var mensaje = await Task.Run(() => new ComplejidadDAO().registrarComplejidad(complejidad));
            return Ok(mensaje);
        }

        //ACTUALIZAR COMPLEJIDAD
        [HttpPut]
        public async Task<IActionResult> actualizarComplejidad(Complejidad complejidad)
        {
            var mensaje = await Task.Run(() => new ComplejidadDAO().actualizarComplejidad(complejidad));
            return Ok(mensaje);
        }

        //ELIMINAR COMPLEJIDAD
        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarComplejidad(int id)
        {
            var mensaje = await Task.Run(() => new ComplejidadDAO().eliminarComplejidad(id));
            return Ok(mensaje);
        }
    }
}
