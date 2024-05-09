using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DSWI_Proyecto_Backend.Repositorio.DAO
{
    public class UsuarioDAO : IUsuario
    {
        private readonly string cadena;

        public UsuarioDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public IEnumerable<Usuario> obtenerUsuarios()
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Usuario usuario = new Usuario();

                usuario.IdUsuario = dr.GetInt32("IdUsuario");
                usuario.Nombre = dr.GetString("Nombre");

                lstUsuarios.Add(usuario);
            }

            dr.Close();
            cn.Close();

            return lstUsuarios;
        }
    }
}
