using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DSWI_Proyecto_Backend.Repositorio.DAO
{
    public class TipoDAO : ITipo
    {

        private readonly string cadena;

        public TipoDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public IEnumerable<Tipo> obtenerTipos()
        {
            List<Tipo> lstTipos = new List<Tipo>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaTipo", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                Tipo tipo = new Tipo();

                tipo.IdTipo = dr.GetInt32("IdTipo");
                tipo.Descripcion = dr.GetString("Descripcion");

                lstTipos.Add(tipo);
            }

            dr.Close();
            cn.Close();

            return lstTipos;
        }

        public Tipo obtenerTipoPorId(int id)
        {
            var tipo = obtenerTipos().Where(t => t.IdTipo == id).FirstOrDefault();
            if (tipo == null)
            {
                return new Tipo();
            } else
            {
                return tipo;
            }
        }

        public string registrarTipo(Tipo tipo)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_addTipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@descripcion", tipo.Descripcion);

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

        public string actualizarTipo(Tipo tipo)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateTipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idtipo", tipo.IdTipo);
                cmd.Parameters.AddWithValue("@descripcion", tipo.Descripcion);

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

        public string eliminarTipo(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteTipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idtipo", id);

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
