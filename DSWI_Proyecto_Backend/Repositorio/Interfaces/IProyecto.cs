using DSWI_Proyecto_Backend.Models;

namespace DSWI_Proyecto_Backend.Repositorio.Interfaces
{
    public interface IProyecto
    {
        IEnumerable<Proyecto> obtenerProyectos();

        Proyecto obtenerProyectoPorId(int id);

        string registrarProyecto(ProyectoOriginal proyectoOriginal);

        string actualizarProyecto(ProyectoOriginal proyectoOriginal);

        string eliminarProyecto(int id);
    }
}
