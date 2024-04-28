using DSWI_Proyecto_Backend.Models;

namespace DSWI_Proyecto_Backend.Repositorio.Interfaces
{
    public interface IPrioridad
    {
        IEnumerable<Prioridad> obtenerPrioridades();

        Prioridad obtenerPrioridadPorId(int id);

        string registrarPrioridad(Prioridad prioridad);

        string actualizarPrioridad(Prioridad prioridad);

        string eliminarPrioridad(int id);
    }
}
