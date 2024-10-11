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
  public class CDEmpleado : Conexion
    {
        public int InsertarEmpleado(CEEmpleado entEmpleado)
        {
            int resultado;
            try
            {
                SqlCommand cmd = new SqlCommand("SpInsertarEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Dni", SqlDbType.VarChar, 8).Value = entEmpleado.DNI;
                cmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = entEmpleado.Nombres;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50).Value = entEmpleado.Apellidos;
                cmd.Parameters.Add("@Sexo", SqlDbType.VarChar, 8).Value = entEmpleado.Sexo;
                cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = entEmpleado.FechaNacimiento;
                cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date).Value = entEmpleado.FechaIngreso;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = entEmpleado.Direccion;
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 9).Value = entEmpleado.Telefono;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit, 9).Value = entEmpleado.Estado;
                cmd.Parameters.Add("@IDCargo", SqlDbType.Int).Value = entEmpleado.oCargo.IDCargo;
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Datos del Empleado", ex);
            }
            finally
            {
                CerrarBD();
            }
            return resultado;
        }

        public int ActualizarEmpleado(CEEmpleado objE)
        {
            int resultado;
            try
            {
                SqlCommand cmd = new SqlCommand("SpActualizarEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDEmpleado", SqlDbType.VarChar, 8).Value = objE.IDEmpleado;
                cmd.Parameters.Add("@Dni", SqlDbType.VarChar, 8).Value = objE.DNI;
                cmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = objE.Nombres;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50).Value = objE.Apellidos;
                cmd.Parameters.Add("@Sexo", SqlDbType.VarChar, 8).Value = objE.Sexo;
                cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = objE.FechaNacimiento;
                cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date).Value = objE.FechaIngreso;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = objE.Direccion;
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 9).Value = objE.Telefono;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit, 9).Value = objE.Estado;
                cmd.Parameters.Add("@IDCargo", SqlDbType.Int).Value = objE.oCargo.IDCargo;
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al tratar de actualizar Datos del Empleado", ex);
            }
            finally
            {
                CerrarBD();
            }
            return resultado;
        }

        public int EliminarEmpleado(CEEmpleado objE)
        {
            int resultado = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SpEliminarEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDEmpleado", SqlDbType.VarChar, 8).Value = objE.IDEmpleado;
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al tratar de eliminar Datos del Empleado", ex);
            }
            finally
            {
                CerrarBD();

            }
            return resultado;
        }

        public DataSet ListadoEmpleado()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("SpListarEmpleado", cn);
                da.Fill(ds, "Empleado");
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al solicitar Datos del Empleado", ex);
            }
            finally
            {
                CerrarBD();
                ds.Dispose();
            }
        }

        public DataSet ComboCargo()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("SpListarComboCargo", cn);
                da.Fill(ds, "Cargo");
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al solicitar Datos del Cargo", ex);
            }
            finally
            {
                CerrarBD();
                ds.Dispose();
            }
        }

        public DataSet ListadoEmpleadoPorNombres(CEEmpleado objE)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("SpBuscarEmpNombre", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = objE.Apellidos;
                da.Fill(ds, "Empleado");
                return ds;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al solicitar los Datos del Empleado", ex);
            }
            finally
            {
                CerrarBD();
                ds.Dispose();
            }
        }

        public DataSet ListadoEmpleadoPordni(CEEmpleado objE)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                ConectarBD();
                da = new SqlDataAdapter("SpBuscarEmpDNI", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Dni", SqlDbType.VarChar, 8).Value = objE.DNI;
                da.Fill(ds, "Empleado");
                return ds;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al solicitar los Datos del Empleado", ex);
            }
            finally
            {
                CerrarBD();
                ds.Dispose();
            }
        }
    }
}
