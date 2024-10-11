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
   public class CNProveedor
    {
        CDProveedor CDC = new CDProveedor();
        public int InsertarProveedor(CEProveedor CEE)
        {
            return CDC.InsertarProveedor(CEE);
        }
        public int ActualizarProveedor(CEProveedor CEE)
        {
            return CDC.ActualizarProveedor(CEE);
        }
        public int EliminarProveedor(CEProveedor CEE)
        {
            return CDC.EliminarProveedor(CEE);
        }
        public DataSet ListadoProveedor()
        {
            return CDC.ListadoProveedor();
        }
        public DataSet BusquedaProveedorPorRznSocial(CEProveedor CEE)
        {
            return CDC.ListadoProveedorPorRznSocial(CEE);
        }
        public DataSet BusquedaProveedorPorRUC(CEProveedor CEE)
        {
            return CDC.ListadoProveedorPorRUC(CEE);
        }
    }
}
