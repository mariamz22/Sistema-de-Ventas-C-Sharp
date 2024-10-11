using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class CEUsuario
    {
        public int IDUsuario { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public CEEmpleado oEmpleado { get; set; }
        public bool Activo { get; set; }
              

    }
}
