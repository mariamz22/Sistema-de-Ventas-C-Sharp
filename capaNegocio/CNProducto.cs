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
   public class CNProducto
    {
        CDProducto objP = new CDProducto();

        public int InsertarProducto(CEProducto objProducto)
        {
            return objP.InsertarProducto(objProducto);
        }
        public int ActualizarProducto(CEProducto objProducto)
        {
            return objP.ActualizarProducto(objProducto);
        }
        public int EliminarProducto(CEProducto objProducto)
        {
            return objP.EliminarProducto(objProducto);
        }
        public DataSet ListadoProducto()
        {
            return objP.ListadoProducto();
        }
        public DataSet ListarComboCategoria()
        {
            return objP.ComboCategoria();
        }
        public DataSet ListarComboPresentacion()
        {
            return objP.ComboPresentacion();
        }
        public DataSet ListarComboLaboratorio()
        {
            return objP.ComboLaboratorio();
        }
    }
}
