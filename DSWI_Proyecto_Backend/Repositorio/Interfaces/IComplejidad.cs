using DSWI_Proyecto_Backend.Models;

namespace DSWI_Proyecto_Backend.Repositorio.Interfaces
{
    public interface IComplejidad
    {
        IEnumerable<Complejidad> obtenerComplejidades();

        Complejidad obtenerComplejidadPorId(int id);

        string registrarComplejidad(Complejidad complejidad);

        string actualizarComplejidad(Complejidad complejidad);

        string eliminarComplejidad(int id);
    }
}
