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
   public class CDLaboratorio : Conexion
    {
        public int InsertarLaboratorio(CELaboratorio objC)
        {
            int resultado;
            try
            {

                SqlCommand cmd = new SqlCommand("SpInsertarLaboratorio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NomLab", SqlDbType.VarChar, 8).Value = objC.NomLaboratorio;

                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al tratar de almacenar Datos de laboratorio", ex);
            }
            finally
            {

                CerrarBD();
            }
            return resultado;
        }

        public int ActualizarLaboratorio(CELaboratorio objC)
        {
            int resultado;
            try
            {

                SqlCommand cmd = new SqlCommand("SpActualizarLaboratorio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDLab", SqlDbType.Int, 8).Value = objC.IDLaboratorio;
                cmd.Parameters.Add("@NomLab", SqlDbType.VarChar, 50).Value = objC.NomLaboratorio;
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al tratar de Actualizar Datos de Laboratorio", ex);
            }
            finally
            {

                CerrarBD();
            }
            return resultado;
        }

        public int EliminarLaboratorio(CELaboratorio objC)
        {
            int resultado = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SpEliminarLaboratorio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDLaboratorio", SqlDbType.Int, 8).Value = objC.IDLaboratorio;

                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al tratar de eliminar Datos Laboratorio", ex);
            }
            finally
            {

                CerrarBD();
            }
            return resultado;
        }

        public DataSet ListadoLaboratorio()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("SpListarLaboratorio", cn);
                da.Fill(ds, "Laboratorio");
                return ds;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al solicitar los datos de los laboratorios", ex);
            }
            finally
            {

                CerrarBD();
                ds.Dispose();
            }
        }

        public DataSet ListadoLaboratorioDesc(CELaboratorio objC)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {

                ConectarBD();
                da = new SqlDataAdapter("SpBuscarLaboratorio", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@NomLab", SqlDbType.VarChar, 50).Value = objC.NomLaboratorio;
                da.Fill(ds, "Laboratorio");
                return ds;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al solicitar los datos de Laboratorio", ex);
            }
            finally
            {
                CerrarBD();
                ds.Dispose();
            }
        }

    }
    
}
