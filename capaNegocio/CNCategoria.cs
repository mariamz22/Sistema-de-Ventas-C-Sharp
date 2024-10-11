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
   public class CNCategoria
    {

        CDCategoria datCategoria = new CDCategoria();
        public int InsertarCategoria(CECategoria entCategoria)
        {
            return datCategoria.InsertarCategoria(entCategoria);
        }
        public int ActualizarCategoria(CECategoria entCategoria)
        {
            return datCategoria.ActualizarCategoria(entCategoria);
        }
        public int EliminarCategoria(CECategoria entCategoria)
        {
            return datCategoria.EliminarCategoria(entCategoria);
        }
        public DataSet ListadoCategoria()
        {
            return datCategoria.ListadoCategoria();
        }
        public DataSet BusquedaCategoriaDesc(CECategoria entCategoria)
        {
            return datCategoria.BusquedaCategoriaDesc(entCategoria);
        }

     
    }
}
