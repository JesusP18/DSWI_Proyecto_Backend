using DSWI_Proyecto_Backend.Models;
using DSWI_Proyecto_Backend.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DSWI_Proyecto_Backend.Repositorio.DAO
{
    public class CategoriaDAO : ICategoria
    {

        private readonly string cadena;

        public CategoriaDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        //LISTAR CATEGORIAS
        public IEnumerable<Categoria> obtenerCategorias()
        {
            List<Categoria> lstCategorias = new List<Categoria>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("usp_listaCategoria", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Categoria categoria = new Categoria();

                categoria.IdCategoria = dr.GetInt32("IdCategoria");
                categoria.Descripcion = dr.GetString("Descripcion");

                lstCategorias.Add(categoria);
            }

            dr.Close();
            cn.Close();

            return lstCategorias;
        }

        //LISTAR CATEGORIA POR ID
        public Categoria obtenerCategoriaPorId(int id)
        {
            var categoria = obtenerCategorias().Where(a => a.IdCategoria == id).FirstOrDefault();
            if (categoria == null)
            {
                return new Categoria();
            }
            else
            {
                return categoria;
            }
        }

        //REGISTRAR CATEGORIA
        public string registrarCategoria(Categoria categoria)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_addCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@descripcion", categoria.Descripcion);

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

        public string actualizarCategoria(Categoria categoria)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_updateCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idcategoria", categoria.IdCategoria);
                cmd.Parameters.AddWithValue("@descripcion", categoria.Descripcion);

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

        public string eliminarCategoria(int id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_deleteCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idcategoria", id);

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
