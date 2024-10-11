using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using capaAccesoDatos;
using capaEntidades;

namespace capaNegocio
{
    public class CNCliente
    {
        CDCliente CDC = new CDCliente();
        public int InsertarCliente(CECliente CEE)
        {
            return CDC.InsertarCliente(CEE);
        }
        public int ActualizarCliente(CECliente CEE)
        {
            return CDC.ActualizarCliente(CEE);
        }
        public int EliminarCliente(CECliente CEE)
        {
            return CDC.EliminarCliente(CEE);
        }
        public DataTable ListadoCliente(CECliente cliCEE)
        {
            return CDC.ListadoCliente(cliCEE);
        }
        public DataSet BusquedaClienteByApellido(CECliente CEE)
        {
            return CDC.ListadoClientePorApellido(CEE);
        }
        public DataSet BusquedaClienteByDNI(CECliente CEE)
        {
            return CDC.ListadoClientePorDNI(CEE);
        }
    }
}
