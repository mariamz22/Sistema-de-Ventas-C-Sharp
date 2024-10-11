using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using capaEntidades;
using capaAccesoDatos;
using System.Configuration;

namespace capaNegocio
{
  public  class CDLogin : Conexion
    {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            public DataTable DLogin(capaEntidades.CEUsuario usu)
            {
                SqlCommand cmd = new SqlCommand("sp_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usu.Usuario);
                cmd.Parameters.AddWithValue("@Password", usu.Password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                return dataTable;
            }
        
    }
}
