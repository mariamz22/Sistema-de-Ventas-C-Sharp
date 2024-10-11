using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class CEVenta
    {
        public int IDVenta { get; set; }
        public DateTime Fecha { get; set; }
        public CECliente oCliente { get; set; }
        public CEEmpleado oEmpleado { get; set; }
        public double Total { get; set; }
        
    }
}
