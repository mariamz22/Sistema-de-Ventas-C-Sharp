using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using capaEntidades;

namespace capaAccesoDatos
{
  public class CDCategoria : Conexion
    {
        public int InsertarCategoria(CECategoria entCat)
        {
            int resultado;
            try
            {
                SqlCommand cmd = new SqlCommand("SpInsertarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NomCategoria", SqlDbType.VarChar, 50).Value = entCat.NomCategoria;

                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex) { throw new Exception("Error al tratar de almacenar Datos de categoria", ex); }
            finally { CerrarBD(); }
            return resultado;
        }

        public int ActualizarCategoria(CECategoria entCat)
        {
            int resultado;
            try
            {
                SqlCommand cmd = new SqlCommand("SpActualizarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDCategoria", SqlDbType.VarChar, 8).Value = entCat.IDCategoria;
                cmd.Parameters.Add("@NomCat", SqlDbType.VarChar, 50).Value = entCat.NomCategoria;
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex) {  throw new Exception("Error al tratar de Actualizar Datos de categoria", ex); }
            finally { CerrarBD(); }
            return resultado;
        }

        public int EliminarCategoria(CECategoria entCat)
        {
            int resultado = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("SpEliminarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDCategoria", SqlDbType.VarChar, 8).Value = entCat.IDCategoria;

                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex) { throw new Exception("Error al tratar de eliminar Datos Categoria", ex); }
            finally { CerrarBD(); }
            return resultado;
        }

        public DataSet ListadoCategoria()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("SpListarCategoria", cn);
                da.Fill(ds, "Categoria");
                return ds;
            }
            catch (Exception ex)   {  throw new Exception("Error al solicitar los datos de los categorias", ex); }
            finally { CerrarBD(); ds.Dispose(); }
        }

        public DataSet BusquedaCategoriaDesc(CECategoria entCat)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("SpBuscarCategoriaDesc", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = entCat.NomCategoria;
                da.Fill(ds, "Categoria");
                return ds;
            }
            catch (Exception ex) { throw new Exception("Error al solicitar los datos de categoria", ex);  }
            finally  {
                CerrarBD();
                ds.Dispose();
            }
        }

    }
    
}
