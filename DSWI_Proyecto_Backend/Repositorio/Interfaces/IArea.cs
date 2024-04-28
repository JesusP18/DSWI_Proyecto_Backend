using DSWI_Proyecto_Backend.Models;

namespace DSWI_Proyecto_Backend.Repositorio.Interfaces
{
    public interface IArea
    {
        IEnumerable<Area> obtenerAreas();

        Area obtenerAreaPorId(int id);

        string registrarArea(Area area);

        string actualizarArea(Area area);

        string eliminarArea(int id);

    }
}
