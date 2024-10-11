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
    public partial class FrmProveedor : Form
    {
        public FrmProveedor()
        {
            InitializeComponent();
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            HabilitarControles(false, true, false, false, false);
            ListadoProveedor();
        }

        private void HabilitarControles(bool panel, bool nuevo, bool guardar, bool actualizar, bool cancelar)
        {
            gbxDatos.Enabled = panel;
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnActualizar.Enabled = actualizar;
            btnCancelar.Enabled = cancelar;
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtRuc.Clear();
            txtRazonSocial.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        private void FilaSeleccionada()
        {
            txtCodigo.Text = dgvLista.SelectedRows[0].Cells[0].Value.ToString();
            txtRuc.Text = dgvLista.SelectedRows[0].Cells[1].Value.ToString();
            txtRazonSocial.Text = dgvLista.SelectedRows[0].Cells[2].Value.ToString();
            txtDireccion.Text = dgvLista.SelectedRows[0].Cells[3].Value.ToString();
            txtTelefono.Text = dgvLista.SelectedRows[0].Cells[4].Value.ToString();
            txtCorreo.Text = dgvLista.SelectedRows[0].Cells[5].Value.ToString();
        }

       private void InsertarProveedor()
        {
            CNProveedor CNE = new CNProveedor();
            CEProveedor CEE = new CEProveedor();
            CEE.IDProveedor = Int32.Parse(txtCodigo.Text.Trim());
            CEE.RUC = txtRuc.Text.Trim();
            CEE.RazonSocial = txtRazonSocial.Text.Trim();
            CEE.Direccion = txtDireccion.Text.Trim();
            CEE.Telefono = txtTelefono.Text.Trim();
            CEE.Correo = txtTelefono.Text.Trim();

            if (CNE.InsertarProveedor(CEE) > 0)
            {
                MessageBox.Show(null, "Registro almacenado satisfactoriamente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "Error al almacenar el Registro Form ", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarProveedor()
        {
            try
            {
                CNProveedor CNE = new CNProveedor();
                CEProveedor CEE = new CEProveedor();
                CEE.IDProveedor = Int32.Parse(txtCodigo.Text.Trim());
                CEE.RUC = txtRuc.Text.Trim();
                CEE.RazonSocial = txtRazonSocial.Text.Trim();
                CEE.Direccion = txtDireccion.Text.Trim();
                CEE.Telefono = txtTelefono.Text.Trim();
                CEE.Correo = txtTelefono.Text.Trim();

                if (CNE.ActualizarProveedor(CEE) > 0)
                {
                    MessageBox.Show(null, "Registro actualizado satisfactoriamente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(null, "Error al actualizar el Registro Form", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void EliminarProveedor(string CodProveedor)
        {
            CNProveedor CNE = new CNProveedor();
            CEProveedor CEE = new CEProveedor();
            CEE.IDProveedor = Int32.Parse(txtCodigo.Text.Trim());

            if (CNE.EliminarProveedor(CEE) > 0)
            {
                MessageBox.Show(null, "Registro eliminado satisfactoriamente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "Error al eliminar el Registro Form", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListadoProveedor()
        {
            CNProveedor CNE = new CNProveedor();
            dgvLista.DataSource = CNE.ListadoProveedor().Tables["Proveedor"];
        }

        private void ListadoByRazonSocial(string RazonSocial)
        {
            CNProveedor CNE = new CNProveedor();
            CEProveedor CEE = new CEProveedor();
            CEE.RazonSocial = RazonSocial;
            dgvLista.DataSource = CNE.BusquedaProveedorPorRznSocial(CEE).Tables["Proveedor"];
            //dgvLista.Columns[0].Visible = false;
            //dgvLista.Columns[1].Visible = false;
        }

        private void ListadoByDNI(string Ruc)
        {
            CNProveedor CNE = new CNProveedor();
            CEProveedor CEE = new CEProveedor();
            CEE.RUC = Ruc;
            dgvLista.DataSource = CNE.BusquedaProveedorPorRUC(CEE).Tables["Proveedor"];
            //dgvLista.Columns[0].Visible = false;
            //dgvLista.Columns[1].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarControles(true, false, true, false, true);
            txtCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilaSeleccionada();
            HabilitarControles(true, false, false, true, true);
            txtCodigo.Enabled = true;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(null, "Esta seguro de eliminar el Registro ", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string CodProveedor;
                CodProveedor = (dgvLista.CurrentRow.Cells[0].Value.ToString());
                EliminarProveedor(CodProveedor);
                ListadoProveedor();
                Limpiar();
                HabilitarControles(false, true, false, false, false);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarControles(false, true, false, false, false);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (!txtBusqueda.Text.Equals(""))
            {
                    ListadoByRazonSocial(txtBusqueda.Text);
                }
                else
                {
                    ListadoByDNI(txtBusqueda.Text);
                }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))

                {
                    e.Handled = true;

                    return;
                }
                else
                {
                    if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))

                    {
                        e.Handled = true;

                        return;
                    }
                }
            }
        }
    }

