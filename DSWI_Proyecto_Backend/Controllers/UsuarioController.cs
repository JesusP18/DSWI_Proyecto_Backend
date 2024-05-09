using DSWI_Proyecto_Backend.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_Proyecto_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerUsuarios()
        {
            var lista = await Task.Run(() => new UsuarioDAO().obtenerUsuarios());
            return Ok(lista);
        }
    }
}
