using DSWI_Proyecto_Backend.Models;

namespace DSWI_Proyecto_Backend.Repositorio.Interfaces
{
    public interface IUsuario
    {
        IEnumerable<Usuario> obtenerUsuarios();
    }
}
