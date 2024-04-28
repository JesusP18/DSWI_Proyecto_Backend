using System.ComponentModel.DataAnnotations;

namespace DSWI_Proyecto_Backend.Models
{
    public class Estado
    {
        private int idEstado;
        private string descripcion;

        public Estado()
        {
            this.idEstado = 0;
            this.descripcion = "";
        }

        public Estado(int idEstado, string descripcion)
        {
            this.idEstado = idEstado;
            this.descripcion = descripcion;
        }

        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
