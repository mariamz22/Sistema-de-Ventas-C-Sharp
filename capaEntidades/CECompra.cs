using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class CECompra
    {
        public int IDCompra { get; set; }
        public int Fecha { get; set; }
        public CEProveedor oProveedor { get; set; }
        public double Total { get; set; }
        
    }
}
