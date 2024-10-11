using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidades;
using capaNegocio;

namespace capaPresentacion
{
    public partial class FrmNuevoProducto : Form
    {
        public bool tipo; // True = nuevo ---- False = modificar
        public FrmNuevoProducto()
        {
            InitializeComponent();
        }
        private void FrmNuevoProducto_Load(object sender, EventArgs e)
        {
            if ( tipo == true){
                btnModificar.Visible = false;
            }
            if (tipo == false)
            {
                btnModificar.Visible = true;
            }
            CargarCategoria();
            CargarPresentacion();
            CargarLaboratorio();
        }
        
        private void CargarCategoria(){
            CNProducto objProducto = new CNProducto();
            cboCategoria.DataSource = objProducto.ListarComboCategoria().Tables["Categoria"];
            cboCategoria.DisplayMember = "NomCategoria";
            cboCategoria.ValueMember = "IDCategoria";

        }
        private void CargarPresentacion() { 
            CNProducto objProducto = new CNProducto();
            cboPresentacion.DataSource = objProducto.ListarComboPresentacion().Tables["Presentacion"];
            cboPresentacion.DisplayMember = "NomPresentacion";
            cboPresentacion.ValueMember = "IDPresentacion";

        }
        private void CargarLaboratorio()
        {
            CNProducto objProducto = new CNProducto();
            cboLaboratorio.DataSource = objProducto.ListarComboLaboratorio().Tables["Laboratorio"];
            cboLaboratorio.DisplayMember = "NomLaboratorio";
            cboLaboratorio.ValueMember = "IDLaboratorio";

        }
        private void Limpiar()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            txtLote.Clear();
            txtStock.Clear();
            cboCategoria.DataSource = null;
            cboPresentacion.DataSource = null;
            cboLaboratorio.DataSource = null;
        }
        private void IngresarProducto(){
            CNProducto objInsertarProducto = new CNProducto();
            CEProducto objProducto = new CEProducto();
            objProducto.IDProducto = Convert.ToInt32(txtCodigo.Text.Trim());
            objProducto.Descripcion = txtDescripcion.Text.Trim();
            objProducto.PrecioCompra = Convert.ToDouble(txtPrecioCompra.Text);
            objProducto.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
            objProducto.oLote.IDLote =Convert.ToInt32(txtLote.Text.Trim());
            objProducto.Stock = Convert.ToInt32(txtStock.Text);
            objProducto.oCategoria.IDCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
            objProducto.oPresentacion.IDPresentacion = Convert.ToInt32(cboPresentacion.SelectedValue);
            objProducto.oLaboratorio.IDLaboratorio = Convert.ToInt32(cboLaboratorio.SelectedValue);


            if (objInsertarProducto.InsertarProducto(objProducto) > 0)
                {
                    MessageBox.Show(null, "Registro almacenado satisfactoriamente", "BOTICA SALDAÑA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(null, "Error al almacenar el registro", "BOTICA SALDAÑA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }           
        }

        private void ActualizarPelicula()
        {
            CNProducto objActualizarProducto = new CNProducto();
            CEProducto objProducto = new CEProducto();
            objProducto.Descripcion = txtDescripcion.Text.Trim();
            objProducto.PrecioCompra = Convert.ToDouble(txtPrecioCompra.Text);
            objProducto.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
            objProducto.oLote.IDLote =Convert.ToInt32(txtLote.Text.Trim());
            objProducto.Stock = Convert.ToInt32(txtStock.Text);
            objProducto.oCategoria.IDCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
            objProducto.oPresentacion.IDPresentacion = Convert.ToInt32(cboPresentacion.SelectedValue);
            objProducto.oLaboratorio.IDLaboratorio = Convert.ToInt32(cboLaboratorio.SelectedValue);
            if (objActualizarProducto.ActualizarProducto(objProducto) > 0)
            {
                MessageBox.Show(null, "Registro actualizado satisfactoriamente", "BOTICA SALDAÑA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "Error al actualizar el registro", "BOTICA SALDAÑA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese la descripcion del Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }
            if (txtPrecioCompra.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el precio de compra de Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioCompra.Focus();
                return;
            }
            if (txtPrecioVenta.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese  el precio de venta de Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioVenta.Focus();
                return;
            }
            if (txtLote.Text == null)
            {
                MessageBox.Show(null, "Ingrese el Nº de Lote del Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLote.Focus();
                return;
            }           
            if (txtStock.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el stock del Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
                return;
            }
            if (cboCategoria.Text == null)
            {
                MessageBox.Show(null, "Seleccione la Categoria del Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCategoria.Focus();
                return;
            }
            if (cboPresentacion.Text == null)
            {
                MessageBox.Show(null, "Seleccione la Presentacion del Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPresentacion.Focus();
                return;
            }
            if (cboLaboratorio.Text == null)
            {
                MessageBox.Show(null, "Seleccione el Laboratorio del Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLaboratorio.Focus();
                return;
            }
            IngresarProducto();
            Limpiar();
           
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese la descripcion del Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return;
            }
            if (txtPrecioCompra.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el precio de compra de Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioCompra.Focus();
                return;
            }
            if (txtPrecioVenta.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese  el precio de venta de Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioVenta.Focus();
                return;
            }
            if (txtLote.Text == null)
            {
                MessageBox.Show(null, "Ingrese el Nº de Lote del Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLote.Focus();
                return;
            }
            if (txtStock.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el stock del Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
                return;
            }
            if (cboCategoria.Text == null)
            {
                MessageBox.Show(null, "Seleccione la Categoria del Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCategoria.Focus();
                return;
            }
            if (cboPresentacion.Text == null)
            {
                MessageBox.Show(null, "Seleccione la Presentacion del Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPresentacion.Focus();
                return;
            }
            if (cboLaboratorio.Text == null)
            {
                MessageBox.Show(null, "Seleccione el Laboratorio del Producto", "Cinema Evolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLaboratorio.Focus();
                return;
            }
            ActualizarPelicula();
            Limpiar();
        }
    }
}
