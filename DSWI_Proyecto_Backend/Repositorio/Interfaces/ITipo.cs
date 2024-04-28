using DSWI_Proyecto_Backend.Models;

namespace DSWI_Proyecto_Backend.Repositorio.Interfaces
{
    public interface ITipo
    {
        IEnumerable<Tipo> obtenerTipos();

        Tipo obtenerTipoPorId(int id);

        string registrarTipo(Tipo tipo);

        string actualizarTipo(Tipo tipo);

        string eliminarTipo(int id);
    }
}
