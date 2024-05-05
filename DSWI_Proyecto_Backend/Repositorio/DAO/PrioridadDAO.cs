using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DSWI_Proyecto_Backend.Repositorio.DAO
{
    public class PrioridadDAO : IPrioridad
    {

        private readonly string cadena;

        public PrioridadDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public IEnumerable<Prioridad> obtenerPrioridades()
        {
            List<Prioridad> lstPrioridades = new List<Prioridad>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaPrioridad", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            { 
                Prioridad prioridad = new Prioridad();

                prioridad.IdPrioridad = dr.GetInt32("IdPrioridad");
                prioridad.Descripcion = dr.GetString("Descripcion");

                lstPrioridades.Add(prioridad);
            }

            dr.Close();
            cn.Close();

            return lstPrioridades;
        }

        public Prioridad obtenerPrioridadPorId(int id)
        {
            var prioridad = obtenerPrioridades().Where(p => p.IdPrioridad == id).FirstOrDefault();
            if(prioridad == null)
            {
                return new Prioridad();
            } else
            {
                return prioridad;
            }
        }

        public string registrarPrioridad(Prioridad prioridad)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_addPrioridad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@descripcion", prioridad.Descripcion);

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

        public string actualizarPrioridad(Prioridad prioridad)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_updatePrioridad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idprioridad", prioridad.IdPrioridad);
                cmd.Parameters.AddWithValue("descripcion", prioridad.Descripcion);

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

        public string eliminarPrioridad(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_deletePrioridad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idprioridad", id);

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
