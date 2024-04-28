using DSWI_Proyecto_Backend.Models;

namespace DSWI_Proyecto_Backend.Repositorio.Interfaces
{
    public interface IEstado
    {
        IEnumerable<Estado> obtenerEstados();

        Estado obtenerEstadoPorId(int id);

        string registrarEstado(Estado estado);

        string actualizarEstado(Estado estado);

        string eliminarEstado(int id);
    }
}
