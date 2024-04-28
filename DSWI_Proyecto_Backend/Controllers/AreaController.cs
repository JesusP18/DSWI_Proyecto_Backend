using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_Proyecto_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {

        //OBTENER AREAS
        [HttpGet]
        public async Task<IActionResult> obtenerAreas()
        {
            var lista = await Task.Run(() => new AreaDAO().obtenerAreas());

            return Ok(lista);
        }

        // OBTENER AREA POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerArea(int id)
        {
            var area = await Task.Run(() => new AreaDAO().obtenerAreaPorId(id));
            return Ok(area);
        }

        //REGISTRAR AREA
        [HttpPost]
        public async Task<IActionResult> registrarArea(Area area)
        {
            var mensaje = await Task.Run(() => new AreaDAO().registrarArea(area));
            return Ok(mensaje);
        }

        //ACTUALIZAR AREA
        [HttpPut]
        public async Task<IActionResult> actualizarArea(Area area)
        {
            var mensaje = await Task.Run(() => new AreaDAO().actualizarArea(area));
            return Ok(mensaje);
        }

        //ELIMINAR AREA
        [HttpDelete]
        public async Task<IActionResult> eliminarArea(int id)
        {
            var mensaje = await Task.Run(() => new AreaDAO().eliminarArea(id));
            return Ok(mensaje);
        }

    }
}
