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
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            HabilitarControles(false, true, false, false, false);
            ListadoCliente();
        }

        private void HabilitarControles(bool panel, bool nuevo, bool guardar, bool actualizar, bool cancelar)
        {
            gbxDatos.Enabled = panel;
            //  btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnActualizar.Enabled = actualizar;
            btnCancelar.Enabled = cancelar;
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtDni.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            dtpFNacimiento.Value = DateTime.Now;
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtAlergias.Clear();
        }

        private void FilaSeleccionada()
        {
            txtCodigo.Text = dgvLista.SelectedRows[0].Cells[0].Value.ToString();
            txtDni.Text = dgvLista.SelectedRows[0].Cells[1].Value.ToString();
            txtNombres.Text = dgvLista.SelectedRows[0].Cells[2].Value.ToString();
            txtApellidos.Text = dgvLista.SelectedRows[0].Cells[3].Value.ToString();
            dtpFNacimiento.Text = dgvLista.SelectedRows[0].Cells[4].Value.ToString();
            txtDireccion.Text = dgvLista.SelectedRows[0].Cells[5].Value.ToString();
            txtTelefono.Text = dgvLista.SelectedRows[0].Cells[6].Value.ToString();
            txtCorreo.Text = dgvLista.SelectedRows[0].Cells[7].Value.ToString();
            txtAlergias.Text = dgvLista.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void ListadoByApellidos(string Apellidos)
        {
            CNCliente CNE = new CNCliente();
            CECliente CEE = new CECliente();
            CEE.Apellidos = Apellidos;
            dgvLista.DataSource = CNE.BusquedaClienteByApellido(CEE).Tables["Cliente"];
            //dgvLista.Columns[0].Visible = false;
            //dgvLista.Columns[1].Visible = false;
        }

        private void ListadoByDNI(string Dni)
        {
            CNCliente CNE = new CNCliente();
            CECliente CEE = new CECliente();
            CEE.DNI = Dni;
            dgvLista.DataSource = CNE.BusquedaClienteByDNI(CEE).Tables["Cliente"];
            //dgvLista.Columns[0].Visible = false;
            //dgvLista.Columns[1].Visible = false;
        }

        private void InsertarCliente()
        {
            CNCliente CNE = new CNCliente();
            CECliente CEE = new CECliente();
            CEE.IDCliente = Int32.Parse(txtCodigo.Text.Trim());
            CEE.DNI = txtDni.Text.Trim();
            CEE.Nombres = txtNombres.Text.Trim();
            CEE.Apellidos = txtApellidos.Text.Trim();
            CEE.FechaNacimiento = DateTime.Parse(dtpFNacimiento.Value.ToString());
            CEE.Direccion = txtDireccion.Text.Trim();
            CEE.Telefono = txtTelefono.Text.Trim();
            CEE.Correo = txtTelefono.Text.Trim();
            CEE.Alergias = txtAlergias.Text.Trim();

            if (CNE.InsertarCliente(CEE) > 0)
            {
                MessageBox.Show(null, "Registro almacenado satisfactoriamente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "Error al almacenar el Registro Form ", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarCliente()
        {
            try
            {
                CNCliente CNE = new CNCliente();
                CECliente CEE = new CECliente();
                CEE.IDCliente = Int32.Parse(txtCodigo.Text.Trim());
                CEE.DNI = txtDni.Text.Trim();
                CEE.Nombres = txtNombres.Text.Trim();
                CEE.Apellidos = txtApellidos.Text.Trim();
                CEE.FechaNacimiento = DateTime.Parse(dtpFNacimiento.Value.ToString());
                CEE.Direccion = txtDireccion.Text.Trim();
                CEE.Telefono = txtTelefono.Text.Trim();
                CEE.Correo = txtTelefono.Text.Trim();
                CEE.Alergias = txtAlergias.Text.Trim();

                if (CNE.ActualizarCliente(CEE) > 0)
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

        private void EliminarCliente(string CodCliente)
        {
            CNCliente CNE = new CNCliente();
            CECliente CEE = new CECliente();
            CEE.IDCliente = Int32.Parse(txtCodigo.Text.Trim());

            if (CNE.EliminarCliente(CEE) > 0)
            {
                MessageBox.Show(null, "Registro eliminado satisfactoriamente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "Error al eliminar el Registro Form", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListadoCliente()
        {
            CNCliente CNE = new CNCliente();
           // dgvLista.DataSource = CNE.ListadoCliente(cliCEE).Tables["Cliente"];
        }

        private void BusquedaClienteByNombre(string Apellido)
        {
            CNCliente CNE = new CNCliente();
            CECliente CEE = new CECliente();
            CEE.Apellidos = Apellido;
            dgvLista.DataSource = CNE.BusquedaClienteByApellido(CEE).Tables["Cliente"];
        }

        private void BusquedaClienteByDNI(string DNI)
        {
            CNCliente CNE = new CNCliente();
            CECliente CEE = new CECliente();
            CEE.DNI = DNI;
            dgvLista.DataSource = CNE.BusquedaClienteByDNI(CEE).Tables["Cliente"];
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarControles(true, false, true, false, true);
            txtCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el Código del Cliente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDni.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el DNI del Cliente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNombres.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el Nombre del Cliente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtApellidos.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el Apellido del Cliente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InsertarCliente();
            Limpiar();
            HabilitarControles(false, true, false, false, false);
            ListadoCliente();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el Código del Cliente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDni.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el DNI del Cliente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNombres.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el Nombre del Cliente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtApellidos.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el Apellido del Cliente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ActualizarCliente();
            Limpiar();
            HabilitarControles(false, true, false, false, false);
            ListadoCliente();
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
                string CodCliente;
                CodCliente = (dgvLista.CurrentRow.Cells[0].Value.ToString());
                EliminarCliente(CodCliente);
                ListadoCliente();
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
                if (rbApellidos.Checked == true)
                {
                    ListadoByApellidos(txtBusqueda.Text);
                }
                else
                {
                    ListadoByDNI(txtBusqueda.Text);
                }
            }
            else
            {
                ListadoCliente();
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (rbApellidos.Checked == true)
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
}
