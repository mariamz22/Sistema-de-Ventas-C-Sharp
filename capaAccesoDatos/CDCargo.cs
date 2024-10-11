using capaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaAccesoDatos
{
    public class CDCargo : Conexion
    {
        public int InsertarCargo(CECargo entCargo)
        {
            int resultado;
            try
            {
                SqlCommand cmd = new SqlCommand("SpInsertarCargo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NomCargo", entCargo.NomCargo);
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex) { throw new Exception("Error al insertar Datos de Cargo", ex); }
            finally { CerrarBD(); }
            return resultado;
        }

        public int ActualizarCargo(CECargo entCargo)
        {
            int resultado;
            try { 
                SqlCommand cmd = new SqlCommand("SpActualizarCargo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NomCargo", entCargo.NomCargo);
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch(Exception ex) { throw new Exception("Error al actualizar Datos de Cargo", ex); } 
            finally {  CerrarBD(); }
            return resultado;
        }

        public int EliminarCargo(CECargo entCargo)
        {
            int resultado = 0;
            try {
                SqlCommand cmd = new SqlCommand("SpEliminarCargo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDCargo", entCargo.IDCargo);
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch( Exception ex) { throw new Exception("Error al eliminar Datos de Cargo", ex); }
            finally { CerrarBD(); }
            return resultado;
        }

        public DataSet ListadoCargo()
        {
            DataSet ds = new DataSet();
            try
            {
                ConectarBD();
                SqlDataAdapter da = new SqlDataAdapter("SpListadoCargo", cn);
                da.Fill(ds,"Cargo");
                return ds;
            }
            catch (Exception ex){throw new Exception("Error al listar Datos de Cargo",ex); }
            finally
            { 
                CerrarBD();
                ds.Dispose();
            }
        }

        public DataSet BusquedaCargo(CECargo entCargo) {
            DataSet ds = new DataSet();
            try
            {
                ConectarBD();
                SqlDataAdapter da = new SqlDataAdapter("SpBusquedaCargo", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Descripcion", entCargo);
                da.Fill(ds, "Cargo");
                return ds;
            }
            catch (Exception ex) { throw new Exception("Error al solicitar los datos de cargo", ex); }
            finally
            {
                CerrarBD();
                ds.Dispose();
            }
        }
    }
}
