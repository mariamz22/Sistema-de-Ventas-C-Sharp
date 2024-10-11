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
  public  class CDProducto : Conexion
    {
        public int InsertarProducto(CEProducto objP)
        {
            int resultado;
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_InsertarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDProducto", SqlDbType.VarChar,8).Value = objP.IDProducto;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 400).Value = objP.Descripcion;
                cmd.Parameters.Add("@PrecioCompra", SqlDbType.Decimal).Value = objP.PrecioCompra;
                cmd.Parameters.Add("@PrecioVenta", SqlDbType.Decimal).Value = objP.PrecioVenta;
                cmd.Parameters.Add("@Lote", SqlDbType.VarChar, 10).Value = objP.oLote.IDLote;                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = objP.Stock;
                cmd.Parameters.Add("@IDCategoria", SqlDbType.Int).Value = objP.oCategoria.IDCategoria;
                cmd.Parameters.Add("@IDPresentacion", SqlDbType.Int).Value = objP.oPresentacion.IDPresentacion;
                cmd.Parameters.Add("@IDLaboratorio", SqlDbType.Int).Value = objP.oLaboratorio.IDLaboratorio;
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al tratar de almacenar", ex);
            }
            finally
            {
                CerrarBD();
            }
            return resultado;
        }

        public int ActualizarProducto(CEProducto objP)
        {
            int resultado;
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_ActualizarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDProducto", SqlDbType.VarChar, 8).Value = objP.IDProducto;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 400).Value = objP.Descripcion;
                cmd.Parameters.Add("@PrecioCompra", SqlDbType.Decimal).Value = objP.PrecioCompra;
                cmd.Parameters.Add("@PrecioVenta", SqlDbType.Decimal).Value = objP.PrecioVenta;
                cmd.Parameters.Add("@Lote", SqlDbType.VarChar, 10).Value = objP.oLote.IDLote;
                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = objP.Stock;
                cmd.Parameters.Add("@IDCategoria", SqlDbType.Int).Value = objP.oCategoria.IDCategoria;
                cmd.Parameters.Add("@IDPresentacion", SqlDbType.Int).Value = objP.oPresentacion.IDPresentacion;
                cmd.Parameters.Add("@IDLaboratorio", SqlDbType.Int).Value = objP.oLaboratorio.IDLaboratorio;
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al tratar de actualizar", ex);
            }
            finally
            {
                CerrarBD();
            }
            return resultado;
        }

        public int EliminarProducto(CEProducto objP)
        {
            int resultado = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_EliminarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDProducto", SqlDbType.NVarChar, 50).Value = objP.IDProducto;
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al tratar de eliminar", ex);
            }
            finally
            {
                CerrarBD();

            }
            return resultado;
        }
        public DataSet ListadoProducto()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("Sp_ListadoProducto", cn);
                da.Fill(ds, "Producto");
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al solicitar los datos de los Productos", ex);
            }
            finally
            {
                CerrarBD();
                ds.Dispose();
            }
        }

        public DataSet ComboCategoria()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("Sp_ListarComboCategoria", cn);
                da.Fill(ds, "Categoria");
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al solicitar los datos de las Categorias", ex);
            }
            finally
            {
                CerrarBD();
                ds.Dispose();
            }
        }

        public DataSet ComboPresentacion()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("Sp_ListarComboPresentacion", cn);
                da.Fill(ds, "Presentacion");
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al solicitar los datos de las Presentaciones", ex);
            }
            finally
            {
                CerrarBD();
                ds.Dispose();
            }
        }

        public DataSet ComboLaboratorio()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("Sp_ListarComboLaboratorio", cn);
                da.Fill(ds, "Laboratorio");
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al solicitar los datos de los Laboratorios", ex);
            }
            finally
            {
                CerrarBD();
                ds.Dispose();
            }
        }
    }
}
