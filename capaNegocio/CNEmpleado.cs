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
   public class CNEmpleado
    {
        CDEmpleado CDE = new CDEmpleado();

        public int InsertarEmpleado(CEEmpleado CEE)
        {
            return CDE.InsertarEmpleado(CEE);
        }
        public int ActualizarEmpleado(CEEmpleado CEE)
        {
            return CDE.ActualizarEmpleado(CEE);
        }
        public int EliminarEmpleado(CEEmpleado CEE)
        {
            return CDE.EliminarEmpleado(CEE);
        }
        public DataSet ListadoEmpleado()
        {
            return CDE.ListadoEmpleado();
        }
        public DataSet ListarComboCargo()
        {
            return CDE.ComboCargo();
        }
        public DataSet BusquedaEmpleadoByNombre(CEEmpleado CEE)
        {
            return CDE.ListadoEmpleadoPorNombres(CEE);
        }

        public DataSet BusquedaEmpleadoByDni(CEEmpleado CEE)
        {
            return CDE.ListadoEmpleadoPordni(CEE);
        }
    }
}
