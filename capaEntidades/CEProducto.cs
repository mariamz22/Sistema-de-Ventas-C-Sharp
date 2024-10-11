using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class CEProducto
    {
        public int IDProducto { get; set; }
        public string CodigoBarras { get; set; }
        public string Descripcion { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }      
        public int Stock { get; set; }
        public CECategoria oCategoria { get; set; }
        public CEPresentacion oPresentacion { get; set; }
        public CELaboratorio oLaboratorio { get; set; }
        public CELote oLote { get; set; }


    }
}
