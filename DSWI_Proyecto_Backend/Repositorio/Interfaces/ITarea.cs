using DSWI_Proyecto_Backend.Models;
using System.Threading;

namespace DSWI_Proyecto_Backend.Repositorio.Interfaces
{
    public interface ITarea
    {
        IEnumerable<Tarea> obtenerTareas();

        Tarea obtenerTareaPorId(int id);

        string registrarTarea(Tarea tarea);

        string actualizarTarea(Tarea tarea);

        string eliminarTarea(int id);
    }
}
