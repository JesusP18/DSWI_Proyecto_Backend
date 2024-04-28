using DSWI_Proyecto_Backend.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DSWI_Proyecto_Backend.Repositorio.DAO
{
    public class TareaDAO
    {

        private readonly string cadena;

        public TareaDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public IEnumerable<Tarea> obtenerTareas()
        {
            List<Tarea> lstTareas = new List<Tarea>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaTarea", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tarea tarea = new Tarea();

                tarea.IdTarea = dr.GetInt32("IdTarea");
                tarea.NombreProyecto = dr.GetString("NombreProyecto");
                tarea.DescripcionTarea = dr.GetString("DescripcionTarea");

                lstTareas.Add(tarea);
            }

            dr.Close();
            cn.Close();

            return lstTareas;
        }

        public Tarea obtenerTareaPorId(int id)
        {
            var tarea = obtenerTareas().Where(t => t.IdTarea == id).FirstOrDefault();
            if (tarea == null)
            {
                return new Tarea();
            }
            else
            {
                return tarea;
            }
        }

        public string registrarTarea(Tarea tarea)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_addTarea", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreproyecto", tarea.NombreProyecto);
                cmd.Parameters.AddWithValue("@descripciontarea", tarea.DescripcionTarea);

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


        public string actualizarTarea(Tarea tarea)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateTarea", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idtarea", tarea.IdTarea);
                cmd.Parameters.AddWithValue("@nombreproyecto", tarea.NombreProyecto);
                cmd.Parameters.AddWithValue("@descripciontarea", tarea.DescripcionTarea);

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

        public string eliminarTarea(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteTarea", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idtarea", id);
              
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
