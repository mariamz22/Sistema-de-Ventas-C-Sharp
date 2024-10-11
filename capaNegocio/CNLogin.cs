using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaAccesoDatos;
using capaEntidades;

namespace capaNegocio
{
   public class CNLogin
    {
        CDLogin objU = new CDLogin();
        public DataTable AccesoUsuario(CEUsuario objLogin)
        {
            return objU.DLogin(objLogin);
        }
    }
}
