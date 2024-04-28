using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DSWI_Proyecto_Backend.Repositorio.DAO
{
    public class ComplejidadDAO : IComplejidad
    {
        private readonly string cadena;

        public ComplejidadDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        //OBTENER LISTA COMPLEJIDAD
        public IEnumerable<Complejidad> obtenerComplejidades()
        {
            List<Complejidad> lstComplejidades = new List<Complejidad>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaComplejidad", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Complejidad complejidad = new Complejidad();

                complejidad.IdComplejidad = dr.GetInt32("IdComplejidad");
                complejidad.Descripcion = dr.GetString("Descripcion");

                lstComplejidades.Add(complejidad);
            }

            dr.Close();
            cn.Close();

            return lstComplejidades;
        }

        //OBTENER COMPLEJIDAD POR ID
        public Complejidad obtenerComplejidadPorId(int id)
        {
            var complejidad = obtenerComplejidades().Where(C => C.IdComplejidad== id).FirstOrDefault();
            if (complejidad == null)
            {
                return new Complejidad();
            }
            else
            {
                return complejidad;
            }
        }

        //REGISTRAR COMPLEJIDAD
        public string registrarComplejidad(Complejidad complejidad)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_addComplejidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@descripcion", complejidad.Descripcion);

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

        //ACTUALIZAR COMPLEJIDAD
        public string actualizarComplejidad(Complejidad complejidad)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateComplejidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idcomplejidad", complejidad.IdComplejidad);
                cmd.Parameters.AddWithValue("@descripcion", complejidad.Descripcion);

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

        //ELIMINAR COMPLEJIDAD
        public string eliminarComplejidad(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteComplejidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idcomplejidad", id);

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
