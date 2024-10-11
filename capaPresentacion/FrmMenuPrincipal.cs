using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void tmsProductos_Click(object sender, EventArgs e)
        {
            FrmProducto productos = new FrmProducto();
            productos.MdiParent = this;
            productos.Show();
        }
               
        private void tmsClientes_Click(object sender, EventArgs e)
        {
            FrmCliente clientes = new FrmCliente();
            clientes.MdiParent = this;
            clientes.Show();
        }

        private void tmsEmpleados_Click(object sender, EventArgs e)
        {
            FrmEmpleado empleado = new FrmEmpleado();
            empleado.MdiParent = this;
            empleado.Show();
        }

        private void tmsProveedores_Click(object sender, EventArgs e)
        {

        }

        private void tmsCategorias_Click(object sender, EventArgs e)
        {
            FrmCategoria categoria = new FrmCategoria();
            categoria.MdiParent = this;
            categoria.Show();
        }

        private void tmsPresentacion_Click(object sender, EventArgs e)
        {

        }

        private void tmsLaboratorio_Click(object sender, EventArgs e)
        {

        }

        private void tmsLote_Click(object sender, EventArgs e)
        {

        }

        private void tmsCompras_Click(object sender, EventArgs e)
        {

        }

        private void tmsVentas_Click(object sender, EventArgs e)
        {

        }
    }
}
