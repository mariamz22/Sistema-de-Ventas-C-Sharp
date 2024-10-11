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
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }

        CNCategoria negCategoria = new CNCategoria();
        CECategoria entCategoria = new CECategoria();
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            ListadoCategoria();
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
            txtNombre.Clear();
        }

        private void FilaSeleccionada()
        {
            txtNombre.Text = dgvLista.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void InsertarCategoria()
        {
            entCategoria.NomCategoria = txtNombre.Text.Trim();
            if (negCategoria.InsertarCategoria(entCategoria) > 0) { MessageBox.Show(null, "Registro guardado", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else { MessageBox.Show(null, "Error al guardar", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ActualizarCategoria()
        {
            try
            {
                entCategoria.NomCategoria = txtNombre.Text.Trim();
                if (negCategoria.ActualizarCategoria(entCategoria) > 0)  { MessageBox.Show(null, "Registro actualizado", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);   }
                else { MessageBox.Show(null, "Error al actualizar", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            } catch (Exception ex) { throw new Exception("Error al actualizar (Form)",ex); }
        }

        private void EliminarCategoria(int id)
        {
            id = Convert.ToInt32(dgvLista.SelectedRows[0].Cells[0].Value);
            entCategoria.IDCategoria = id;
            if (negCategoria.EliminarCategoria(entCategoria) > 0){ MessageBox.Show(null, "Registro eliminado", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else { MessageBox.Show(null, "Error al eliminar", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ListadoCategoria()
        {
           dgvLista.DataSource = negCategoria.ListadoCategoria().Tables["Categoria"];
        }

        private void BusquedaCategoriaByNombre(string Nombre)
        {
            entCategoria.NomCategoria = Nombre;
            dgvLista.DataSource = negCategoria.BusquedaCategoriaDesc(entCategoria).Tables["Categoria"];
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilaSeleccionada();
            HabilitarControles(false, false, true, true);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(null, "Esta seguro de eliminar el Registro ", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
            int CodCategoria;
            CodCategoria = Convert.ToInt32(dgvLista.SelectedRows[0].Cells[0].Value.ToString());
            EliminarCategoria(CodCategoria);
            ListadoCategoria();
            Limpiar();
            HabilitarControles(true, false, false, false);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
          
            if (txtNombre.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingresa el nombre", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InsertarCategoria();
            Limpiar();
            HabilitarControles(true, false, false, false);
            ListadoCategoria();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarCategoria();
            Limpiar();
            HabilitarControles(true, false, false, false);
            ListadoCategoria();
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
                ListadoCategoria();
            }
            else
            {
                BusquedaCategoriaByNombre(txtBusqueda.Text);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            HabilitarControles(false, true, false, true);
            txtNombre.Focus();
        }
    }
}
