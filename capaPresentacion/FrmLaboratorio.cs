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
    public partial class FrmLaboratorio : Form
    {
        public FrmLaboratorio()
        {
            InitializeComponent();
        }

        private void FrmLaboratorio_Load(object sender, EventArgs e)
        {
            ListadoLaboratorio();
            HabilitarControles(true, false, false, false);
        }

        private void HabilitarControles(bool nuevo, bool guardar, bool actualizar, bool cancelar)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnActualizar.Enabled = actualizar;
            btnCancelar.Enabled = cancelar;
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
        }

        private void FilaSelccionada()
        {
            txtCodigo.Text = dgvLista.SelectedRows[0].Cells[0].Value.ToString();
            txtNombre.Text = dgvLista.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void InsertarLaboratorio()
        {
            CNLaboratorio CNE = new CNLaboratorio();
            CELaboratorio CEE = new CELaboratorio();
            CEE.IDLaboratorio = Int32.Parse(txtCodigo.Text.Trim());
            CEE.NomLaboratorio = txtNombre.Text.Trim();

            if (CNE.InsertarLaboratorio(CEE) > 0)
            {
                MessageBox.Show(null, "Registro almacenado satisfactoriamente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "Error al almacenar el Registro Form ", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarLaboratorio()
        {
            try
            {
                CNLaboratorio CNE = new CNLaboratorio();
                CELaboratorio CEE = new CELaboratorio();
                CEE.IDLaboratorio = Int32.Parse(txtCodigo.Text.Trim());
                CEE.NomLaboratorio = txtNombre.Text.Trim();

                if (CNE.ActualizarLaboratorio(CEE) > 0)
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

        private void EliminarLaboratorio(string CodLaboratorio)
        {
            CNLaboratorio CNE = new CNLaboratorio();
            CELaboratorio CEE = new CELaboratorio();
            CEE.IDLaboratorio = Convert.ToInt32(dgvLista.SelectedRows[0].Cells[0].Value);

            if (CNE.EliminarLaboratorio(CEE) > 0)
            {
                MessageBox.Show(null, "Registro eliminado satisfactoriamente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "Error al eliminar el Registro Form", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListadoLaboratorio()
        {
            CNLaboratorio CNE = new CNLaboratorio();
            dgvLista.DataSource = CNE.ListadoLaboratorio().Tables["Laboratorio"];
        }

        private void BusquedaLaboratorioByNombre(string Nombre)
        {
            CNLaboratorio CNE = new CNLaboratorio();
            CELaboratorio CEE = new CELaboratorio();
            CEE.NomLaboratorio = Nombre;
            dgvLista.DataSource = CNE.BusquedaLaboratorioDesc(CEE).Tables["Laboratorio"];
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FilaSelccionada();
            HabilitarControles(false, false, true, true);
            txtCodigo.Enabled = true;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(null, "Esta seguro de eliminar el Registro ", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string CodLaboratorio;
                CodLaboratorio = (dgvLista.SelectedRows[0].Cells[0].Value.ToString());
                EliminarLaboratorio(CodLaboratorio);
                ListadoLaboratorio();
                Limpiar();
                HabilitarControles(true, false, false, false);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el Código de la Laboratorio", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNombre.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el DNI de la Laboratorio", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InsertarLaboratorio();
            Limpiar();
            HabilitarControles(true, false, false, false);
            ListadoLaboratorio();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarLaboratorio();
            Limpiar();
            HabilitarControles(true, false, false, false);
            ListadoLaboratorio();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarControles(false, true, false, true);
            txtCodigo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarControles(true, false, false, false);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text.Equals(""))
            {
                ListadoLaboratorio();
            }
            else
            {
                BusquedaLaboratorioByNombre(txtBusqueda.Text);
            }
        }
    }
}
