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
    public class CDCliente : Conexion
    {
        public int InsertarCliente(CECliente objC)
        {
            int resultado;
            try{

                SqlCommand cmd = new SqlCommand("SpInsertarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DNI", SqlDbType.VarChar, 8).Value = objC.DNI;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = objC.Nombres;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50).Value = objC.Apellidos;
                cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = objC.FechaNacimiento;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = objC.Direccion;
                cmd.Parameters.Add("@Telefono", SqlDbType.Char, 9).Value = objC.Telefono;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objC.Correo;
                cmd.Parameters.Add("@Alergias", SqlDbType.VarChar, 200).Value = objC.Alergias;

                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }catch (Exception ex){

                throw new Exception("Error al tratar de almacenar Datos del cliente", ex);
            }finally{

                CerrarBD();
            }
            return resultado;
        }

        public int ActualizarCliente(CECliente objC)
        {
            int resultado;
            try{

                SqlCommand cmd = new SqlCommand("SpActualizarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDCliente", SqlDbType.Int, 8).Value = objC.IDCliente;
                cmd.Parameters.Add("@DNI", SqlDbType.VarChar, 8).Value = objC.DNI;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = objC.Nombres;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50).Value = objC.Apellidos;
                cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = objC.FechaNacimiento;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = objC.Direccion;
                cmd.Parameters.Add("@Telefono", SqlDbType.Char, 9).Value = objC.Telefono;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objC.Correo;
                cmd.Parameters.Add("@Alergias", SqlDbType.VarChar, 200).Value = objC.Alergias;
                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }catch (Exception ex){

                throw new Exception("Error al tratar de Actualizar Datos del Cliente", ex);
            }finally{

                CerrarBD();
            }
            return resultado;
        }

        public int EliminarCliente(CECliente objC)
        {
            int resultado = 0;
            try{

                SqlCommand cmd = new SqlCommand("SpEliminarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IDCliente", SqlDbType.Int, 8).Value = objC.IDCliente;

                ConectarBD();
                resultado = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }catch (Exception ex){

                throw new Exception("Error al tratar de eliminar Datos Cliente", ex);
            }finally{

                CerrarBD();
            }
            return resultado;
        }
        public DataTable ListadoCliente(CECliente cli)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("SpListarCliente", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        
        public DataSet ListadoClientePorApellido(CECliente objC)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try{

                ConectarBD();
                da = new SqlDataAdapter("SpBuscarCliApellido", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = objC.Apellidos;
                da.Fill(ds, "Cliente");
                return ds;
            }catch (Exception ex){

                throw new Exception("Error al solicitar los datos de los Clientes", ex);
            }
            finally{
                CerrarBD();
                ds.Dispose();
            }
        }
        
        public DataSet ListadoClientePorDNI(CECliente objC)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            try{
                ConectarBD();
                da = new SqlDataAdapter("SpBuscarCliDni", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DNI", SqlDbType.VarChar, 8).Value = objC.DNI;
                da.Fill(ds, "Cliente");
                return ds;
            }catch (Exception ex){

                throw new Exception("Error al solicitar los datos de los Clientes", ex);
            }finally{
                CerrarBD();
                ds.Dispose();
            }
        }
    }
}
