using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DSWI_Proyecto_Backend.Repositorio.DAO
{
    public class ProyectoDAO : IProyecto
    {

        private readonly string cadena;

        public ProyectoDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public IEnumerable<Proyecto> obtenerProyectos()
        {
            List<Proyecto> lstProyectos = new List<Proyecto>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaProyecto", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                Proyecto proyecto = new Proyecto();

                proyecto.IdProyecto = dr.GetInt32("IdProyecto");
                proyecto.NombreProyecto = dr.GetString("NombreProyecto");
                proyecto.DescripcionProyecto = dr.GetString("DescripcionProyecto");
                proyecto.DescripcionTarea = dr.GetString("DescripcionTarea");
                proyecto.DescripcionCategoria = dr.GetString("DescripcionCategoria");
                proyecto.DescripcionEstado = dr.GetString("DescripcionEstado");
                proyecto.DescripcionPrioridad = dr.GetString("DescripcionPrioridad");
                proyecto.DescripcionComplejidad = dr.GetString("DescripcionComplejidad");
                proyecto.FechaInicio = dr.GetDateTime("FechaInicio");
                proyecto.FechaFin = dr.GetDateTime("FechaFin");
                proyecto.Mes = dr.GetString("Mes");
                proyecto.NombreUsuario = dr.GetString("NombreUsuario");
                proyecto.DescripcionArea = dr.GetString("DescripcionArea");
                proyecto.DescripcionTipo = dr.GetString("DescripcionTipo");
                proyecto.Presupuesto = dr.GetDecimal("Presupuesto");
                proyecto.Asignado = dr.GetString("Asignado");
                proyecto.Comentarios = dr.GetString("Comentarios");

                lstProyectos.Add(proyecto);

            }

            dr.Close();
            cn.Close();

            return lstProyectos;
        }

        public Proyecto obtenerProyectoPorId(int id)
        {
            var proyecto = obtenerProyectos().Where(p => p.IdProyecto == id).FirstOrDefault();
            if (proyecto == null)
            {
                return new Proyecto();
            } else
            {
                return proyecto;
            }
        }

        public string registrarProyecto(ProyectoOriginal proyectoOriginal)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_addProyecto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreproyecto", proyectoOriginal.NombreProyecto);
                cmd.Parameters.AddWithValue("@descripcionproyecto", proyectoOriginal.DescripcionProyecto);
                cmd.Parameters.AddWithValue("@idtarea", proyectoOriginal.IdTarea);
                cmd.Parameters.AddWithValue("@idcategoria", proyectoOriginal.IdCategoria);
                cmd.Parameters.AddWithValue("@idestado", proyectoOriginal.IdEstado);
                cmd.Parameters.AddWithValue("@idprioridad", proyectoOriginal.IdPrioridad);
                cmd.Parameters.AddWithValue("@idcomplejidad", proyectoOriginal.IdComplejidad);
                cmd.Parameters.AddWithValue("@fechainicio", proyectoOriginal.FechaInicio);
                cmd.Parameters.AddWithValue("@fechafin", proyectoOriginal.FechaFin);
                cmd.Parameters.AddWithValue("@mes", proyectoOriginal.Mes);
                cmd.Parameters.AddWithValue("@idusuario", proyectoOriginal.IdUsuario);
                cmd.Parameters.AddWithValue("@idarea", proyectoOriginal.IdArea);
                cmd.Parameters.AddWithValue("@idtipo", proyectoOriginal.IdTipo);
                cmd.Parameters.AddWithValue("@presupuesto", proyectoOriginal.Presupuesto);
                cmd.Parameters.AddWithValue("@asignado", proyectoOriginal.Asignado);
                cmd.Parameters.AddWithValue("@porcentaje", proyectoOriginal.Porcentaje);
                cmd.Parameters.AddWithValue("@comentarios", proyectoOriginal.Comentarios);

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

        public string actualizarProyecto(ProyectoOriginal proyectoOriginal)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateProyecto", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@idproyecto", proyectoOriginal.IdProyecto);
                cmd.Parameters.AddWithValue("@nombreproyecto", proyectoOriginal.NombreProyecto);
                cmd.Parameters.AddWithValue("@descripcionproyecto", proyectoOriginal.DescripcionProyecto);
                cmd.Parameters.AddWithValue("@idtarea", proyectoOriginal.IdTarea);
                cmd.Parameters.AddWithValue("@idcategoria", proyectoOriginal.IdCategoria);
                cmd.Parameters.AddWithValue("@idestado", proyectoOriginal.IdEstado);
                cmd.Parameters.AddWithValue("@idprioridad", proyectoOriginal.IdPrioridad);
                cmd.Parameters.AddWithValue("@idcomplejidad", proyectoOriginal.IdComplejidad);
                cmd.Parameters.AddWithValue("@fechainicio", proyectoOriginal.FechaInicio);
                cmd.Parameters.AddWithValue("@fechafin", proyectoOriginal.FechaFin);
                cmd.Parameters.AddWithValue("@mes", proyectoOriginal.Mes);
                cmd.Parameters.AddWithValue("@idusuario", proyectoOriginal.IdUsuario);
                cmd.Parameters.AddWithValue("@idarea", proyectoOriginal.IdArea);
                cmd.Parameters.AddWithValue("@idtipo", proyectoOriginal.IdTipo);
                cmd.Parameters.AddWithValue("@presupuesto", proyectoOriginal.Presupuesto);
                cmd.Parameters.AddWithValue("@asignado", proyectoOriginal.Asignado);
                cmd.Parameters.AddWithValue("@porcentaje", proyectoOriginal.Porcentaje);
                cmd.Parameters.AddWithValue("@comentarios", proyectoOriginal.Comentarios);

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

        public string eliminarProyecto(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteProyecto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idproyecto", id);

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
