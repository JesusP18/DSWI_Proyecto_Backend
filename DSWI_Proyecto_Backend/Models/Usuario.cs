namespace DSWI_Proyecto_Backend.Models
{
    public class Usuario
    {
        private int idUsuario;
        private string nombre;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Usuario(int idUsuario, string nombre)
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
        }

        public Usuario()
        {
            this.idUsuario = 0;
            this.nombre = "";
        }
    }
}
