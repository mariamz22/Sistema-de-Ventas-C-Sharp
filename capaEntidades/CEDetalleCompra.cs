using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class CEDetalleCompra
    {
        public int IDDetalleCompra {get; set;}
        public CECompra oCompra { get; set; }
        public CEProducto oProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double SubTotal { get; set; }
                
    }
}
