using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class CEDetalleVenta
    {
        public int IDDetalleVenta { get; set; }
        public CEVenta oVenta { get; set; }
        public CEProducto oProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioVenta { get; set; }
        public double Descuento { get; set; }
        public double Subtotal { get; set; }
        
    }
}
