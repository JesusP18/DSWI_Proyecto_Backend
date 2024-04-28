using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DSWI_Proyecto_Backend.Repositorio.DAO
{
    public class EstadoDAO : IEstado
    {

        private readonly string cadena;

        public EstadoDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public IEnumerable<Estado> obtenerEstados()
        {
            List<Estado> lstEstados = new List<Estado>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaEstado", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                Estado estado = new Estado();

                estado.IdEstado = dr.GetInt32("IdEstado");
                estado.Descripcion = dr.GetString("Descripcion");

                lstEstados.Add(estado);
            }

            dr.Close();
            cn.Close();

            return lstEstados;
        }

        public Estado obtenerEstadoPorId(int id)
        {
            var estado = obtenerEstados().Where(e => e.IdEstado == id).FirstOrDefault();
            if(estado == null)
            {
                return new Estado();
            } else
            {
                return estado;
            }
        }

        public string registrarEstado(Estado estado)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_addEstado", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@descripcion", estado.Descripcion);

                resultado = cmd.ExecuteNonQuery();
                mensaje = "Registro exitoso - cantidad de filas insertadas " + resultado;

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }

        public string actualizarEstado(Estado estado)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateEstado", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idestado", estado.IdEstado);
                cmd.Parameters.AddWithValue("@descripcion", estado.Descripcion);

                resultado = cmd.ExecuteNonQuery();
                mensaje = "Actualización exitosa - cantidad de filas actualizadas " + resultado;

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return mensaje;

        }

        public string eliminarEstado(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteEstado", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idestado", id);

                resultado = cmd.ExecuteNonQuery();
                mensaje = "Eliminación exitosa - cantidad de filas eliminadas " + resultado;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }
       
    }
}
