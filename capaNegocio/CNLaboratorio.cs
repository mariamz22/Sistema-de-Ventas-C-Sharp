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
   public class CNLaboratorio
    {
        CDLaboratorio CDC = new CDLaboratorio();
        public int InsertarLaboratorio(CELaboratorio CEE)
        {
            return CDC.InsertarLaboratorio(CEE);
        }
        public int ActualizarLaboratorio(CELaboratorio CEE)
        {
            return CDC.ActualizarLaboratorio(CEE);
        }
        public int EliminarLaboratorio(CELaboratorio CEE)
        {
            return CDC.EliminarLaboratorio(CEE);
        }
        public DataSet ListadoLaboratorio()
        {
            return CDC.ListadoLaboratorio();
        }
        public DataSet BusquedaLaboratorioDesc(CELaboratorio CEE)
        {
            return CDC.ListadoLaboratorioDesc(CEE);
        }

    }
}
