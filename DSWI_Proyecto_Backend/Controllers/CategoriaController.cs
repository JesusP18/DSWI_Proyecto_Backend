using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_Proyecto_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        //OBTENER CATEGORIAS
        [HttpGet]
        public async Task<IActionResult> obtenerCategorias()
        {
            var lista = await Task.Run(() => new CategoriaDAO().obtenerCategorias());
            return Ok(lista);
        }

        //OBTENER CATEGORIA POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerCategoria(int id)
        {
            var categoria = await Task.Run(() => new CategoriaDAO().obtenerCategoriaPorId(id));
            return Ok(categoria);
        }

        //REGISTRAR CATEGORIA
        [HttpPost]
        public  async Task<IActionResult> registrarCategoria(Categoria categoria)
        {
            var mensaje = await Task.Run(() => new CategoriaDAO().registrarCategoria(categoria));
            return Ok(mensaje);
        }

        //ACTUALIZAR CATEGORIA
        [HttpPut]
        public async Task<IActionResult> actualizarCategoria(Categoria categoria)
        {
            var mensaje = await Task.Run(() => new CategoriaDAO().actualizarCategoria(categoria));
            return Ok(mensaje);
        }

        //ELIMINAR CATEGORIA
        [HttpDelete]
        public async Task<IActionResult> eliminarCategoria(int id)
        {
            var mensaje = await Task.Run(() => new CategoriaDAO().eliminarCategoria(id));
            return Ok(mensaje);
        }


    }
}
