using DSWI_Proyecto_Backend.Models;

namespace DSWI_Proyecto_Backend.Repositorio.Interfaces
{
    public interface ICategoria
    {
        IEnumerable<Categoria> obtenerCategorias();

        Categoria obtenerCategoriaPorId(int id);

        string registrarCategoria(Categoria categoria);

        string actualizarCategoria(Categoria categoria);

        string eliminarCategoria(int id);
    }
}
