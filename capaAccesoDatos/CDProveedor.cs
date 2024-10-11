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
   public class CDProveedor : Conexion
    {

        public int InsertarProveedor(CEProveedor objP)
        {
            int resultado;
            try
            {
                SqlCommand cmd = new SqlCommand("SpInsertarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDProveedor", SqlDbType.VarChar, 8).Value = objP.IDProveedor;
                cmd.Parameters.Add("@RUC", SqlDbType.VarChar, 8).Value = objP.RUC;
                cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 50).Value = objP.RazonSocial;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = objP.Direccion;
                cmd.Parameters.Add("@Telefono", SqlDbType.Char, 9).Value = objP.Telefono;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objP.Correo;
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al tratar de almacenar Datos del Proveedor", ex);
            }
            finally
            {

                CerrarBD();
            }
            return resultado;
        }

        public int ActualizarProveedor(CEProveedor objP)
        {
            int resultado;
            try
            {

                SqlCommand cmd = new SqlCommand("SpActualizarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDProveedor", SqlDbType.VarChar, 8).Value = objP.IDProveedor;
                cmd.Parameters.Add("@RUC", SqlDbType.VarChar, 8).Value = objP.RUC;
                cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 50).Value = objP.RazonSocial;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = objP.Direccion;
                cmd.Parameters.Add("@Telefono", SqlDbType.Char, 9).Value = objP.Telefono;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objP.Correo;
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al tratar de Actualizar Datos del Proveedor", ex);
            }
            finally
            {

                CerrarBD();
            }
            return resultado;
        }

        public int EliminarProveedor(CEProveedor objP)
        {
            int resultado = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SpEliminarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDProveedor", SqlDbType.VarChar, 8).Value = objP.IDProveedor;

                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al tratar de eliminar Datos Proveedor", ex);
            }
            finally
            {

                CerrarBD();
            }
            return resultado;
        }

        public DataSet ListadoProveedor()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("SpListarProveedor", cn);
                da.Fill(ds, "Proveedor");
                return ds;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al solicitar los datos de los Proveedores", ex);
            }
            finally
            {

                CerrarBD();
                ds.Dispose();
            }
        }

        public DataSet ListadoProveedorPorRznSocial(CEProveedor objP)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {

                ConectarBD();
                da = new SqlDataAdapter("SpBuscarProvRznSocial", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 50).Value = objP.RazonSocial;
                da.Fill(ds, "Proveedor");
                return ds;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al solicitar los datos de los Proveedores", ex);
            }
            finally
            {
                CerrarBD();
                ds.Dispose();
            }
        }

        public DataSet ListadoProveedorPorRUC(CEProveedor objP)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("SpBuscarProvRUC", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@RUC", SqlDbType.VarChar, 8).Value = objP.RUC;
                da.Fill(ds, "Proveedor");
                return ds;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al solicitar los datos de los Proveedores", ex);
            }
            finally
            {
                CerrarBD();
                ds.Dispose();
            }
        }
    }
}
