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
using System.Text.RegularExpressions;
using Microsoft.Office.Interop;

namespace capaPresentacion
{
    public partial class FrmEmpleado : Form
    {
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            HabilitarControles(false, true, false, false, false);
            ListadoEmpleado();
            ListadoCargo();
        }

        private void HabilitarControles(bool panel, bool nuevo, bool guardar, bool actualizar, bool cancelar)
        {
            pnlDatos.Enabled = panel;
            btnNuevo.Enabled = nuevo;
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
            txtSueldo.Clear();
            dtpFNacimiento.Value = DateTime.Now;
            dtpFIngreso.Value = DateTime.Now;
            cboEstado.SelectedIndex = 0;
            rbFemenino.Checked = false;
            rbMasculino.Checked = false;
            txtDireccion.Clear();
            txtTelefono.Clear();
            cboCargo.SelectedIndex = 0;
        }

        private void FilaSeleccionada()
        {
            txtCodigo.Text = dgvLista.SelectedRows[0].Cells[0].Value.ToString();
            txtNombres.Text = dgvLista.SelectedRows[0].Cells[1].Value.ToString();
            txtApellidos.Text = dgvLista.SelectedRows[0].Cells[2].Value.ToString();
            txtDni.Text = dgvLista.SelectedRows[0].Cells[3].Value.ToString();
            if (dgvLista.SelectedRows[0].Cells[4].Value.ToString().Trim() == "Femenino")
            {
                rbFemenino.Checked = true;
            }
            else
            {
                rbMasculino.Checked = true;
            }
            cboCargo.Text = dgvLista.SelectedRows[0].Cells[5].Value.ToString();
            dtpFNacimiento.Value = Convert.ToDateTime(dgvLista.SelectedRows[0].Cells[6].Value.ToString());
            dtpFIngreso.Text = dgvLista.SelectedRows[0].Cells[7].Value.ToString();
            txtDireccion.Text = dgvLista.SelectedRows[0].Cells[8].Value.ToString();
            txtTelefono.Text = dgvLista.SelectedRows[0].Cells[9].Value.ToString();
            txtSueldo.Text = dgvLista.SelectedRows[0].Cells[10].Value.ToString();
            cboEstado.Text = dgvLista.SelectedRows[0].Cells[11].Value.ToString();

        }

        private void InsertarEmpleado()
        {
            CNEmpleado CNE = new CNEmpleado();
            CEEmpleado CEE = new CEEmpleado();
            CEE.IDEmpleado = Int32.Parse(txtCodigo.Text.Trim());
            CEE.DNI = txtDni.Text.Trim();
            CEE.Nombres = txtNombres.Text.Trim();
            CEE.Apellidos = txtApellidos.Text.Trim();
            CEE.FechaNacimiento = dtpFNacimiento.Value.ToString();
            CEE.FechaIngreso = dtpFIngreso.Value.ToString();
            CEE.Direccion = txtDireccion.Text.Trim();
            CEE.Telefono = txtTelefono.Text.Trim();
            if (cboEstado.Text == "Activo"){
                CEE.Estado = true;
            }
            else
            {
                CEE.Estado = false;
            }
            CEE.oCargo.IDCargo = Convert.ToInt32(cboCargo.SelectedValue);
            if (rbFemenino.Checked == true){
                CEE.Sexo = rbFemenino.Text.Trim();
            }
            else
            {
                CEE.Sexo = rbMasculino.Text.Trim();
            }

            if (CNE.InsertarEmpleado(CEE) > 0)
            {
                MessageBox.Show(null, "Registro almacenado satisfactoriamente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "Error al almacenar el Registro Form ", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEmpleado()
        {
            try
            {
                CNEmpleado CNE = new CNEmpleado();
                CEEmpleado CEE = new CEEmpleado();
                CEE.IDEmpleado = Int32.Parse(txtCodigo.Text.Trim());
                CEE.DNI = txtDni.Text.Trim();
                CEE.Nombres = txtNombres.Text.Trim();
                CEE.Apellidos = txtApellidos.Text.Trim();
                CEE.FechaNacimiento = dtpFNacimiento.Value.ToString();
                CEE.FechaIngreso = dtpFIngreso.Value.ToString();
                CEE.Direccion = txtDireccion.Text.Trim();
                CEE.Telefono = txtTelefono.Text.Trim();
                CEE.oCargo.IDCargo = Convert.ToInt32(cboCargo.SelectedValue);
                if (rbFemenino.Checked == true)
                {
                    CEE.Sexo = rbFemenino.Text.Trim();
                }
                else
                {
                    CEE.Sexo = rbMasculino.Text.Trim();
                }
                if (cboEstado.Text == "Activo")
                {
                    CEE.Estado = true;
                }
                else
                {
                    CEE.Estado = false;
                }

                if (CNE.ActualizarEmpleado(CEE) > 0)
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

        private void EliminarEmpleado(string CodEmpleado)
        {
            CNEmpleado CNE = new CNEmpleado();
            CEEmpleado CEE = new CEEmpleado();
            CEE.IDEmpleado = Int32.Parse(txtCodigo.Text.Trim());

            if (CNE.EliminarEmpleado(CEE) > 0)
            {
                MessageBox.Show(null, "Registro eliminado satisfactoriamente", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "Error al eliminar el Registro Form", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListadoEmpleado()
        {
            CNEmpleado CNE = new CNEmpleado();
            dgvLista.DataSource = CNE.ListadoEmpleado().Tables["Empleado"];
        }

        private void BusquedaEmpleadoByNombres(string apellidos)
        {
            CNEmpleado CNE = new CNEmpleado();
            CEEmpleado CEE = new CEEmpleado();
            CEE.Apellidos = apellidos;
            dgvLista.DataSource = CNE.BusquedaEmpleadoByNombre(CEE).Tables["Empleado"];
        }

        private void BusquedaEmpleadoByDni(string dni)
        {
            CNEmpleado CNE = new CNEmpleado();
            CEEmpleado CEE = new CEEmpleado();
            CEE.DNI = dni;
            dgvLista.DataSource = CNE.BusquedaEmpleadoByDni(CEE).Tables["Empleado"];
        }
        private void ListadoCargo()
        {
            CNEmpleado CNE = new CNEmpleado();
            cboCargo.DataSource = CNE.ListarComboCargo().Tables["Cargo"];
            cboCargo.DisplayMember = "Cargo";
            cboCargo.ValueMember = "IDCargo";
        }        
        private void ExportarDataGridViewExcel()
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {

                Microsoft.Office.Interop.Excel.Application aplicacion = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook libro = aplicacion.Workbooks.Add();
                Microsoft.Office.Interop.Excel.Worksheet hoja = libro.Worksheets.get_Item(1);

            hoja.Activate();
            hoja.Range["A1:E1"].Merge();
            hoja.Range["A1:E1"].Font.Bold = true;
            hoja.Range["A1:E1"].Font.Color = Color.Orange;
            hoja.Range["A1:E1"].Font.Size = 16;
            hoja.Range["A1:E1"].Value = "Reporte de Empleados";

            int i = 2;
            hoja.Cells[i, "A"] = "Codigo";
            hoja.Cells[i, "B"] = "Codigo";
            hoja.Cells[i, "C"] = "Codigo";
            hoja.Cells[i, "D"] = "Codigo";
            hoja.Cells[i, "E"] = "Codigo";
            hoja.Range["A2:E2"].Font.Color = Color.Black;
            hoja.Range["A2:E2"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            hoja.Range["A2:E2"].Font.Bold = true;
            hoja.Range["A2:E2"].Font.Name = "Arial";
            hoja.Range["A2:E2"].Font.FontStyle = "Normal";

            int f = 0;
            for (f = 0; f < dgvLista.Rows.Count; f++)
            {
                for (int c = 0; c < dgvLista.ColumnCount; c++) {
                    hoja.Cells[f + 3, c + 1] = dgvLista.Rows[i].Cells[c].Value.ToString();
                }
            }
            f = f + 2;

            hoja.Range["A3:E" + "" + f.ToString() + ""].Borders.LineStyle =
                Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            hoja.Range["A3:E" + "" + f.ToString() + ""].Font.Name = "Arial";
            hoja.Range["A3:E" + "" + f.ToString() + ""].Font.FontStyle = "Normal";
            hoja.Range["A3:E" + "" + f.ToString() + ""].Font.Size = 10;

            hoja.Range["A2:E2"].Interior.ColorIndex = 19;
            hoja.Columns.AutoFit();
            hoja.Range["A1:E1"].HorizontalAlignment = 3;

                libro.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libro.Close(true);
                aplicacion.Quit();
            }
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
                MessageBox.Show(null, "Ingrese el Código del Empleado", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDni.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el DNI del Empleado", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNombres.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el Nombres del Empleado", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtApellidos.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el Apellido del Empleado", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InsertarEmpleado();
            Limpiar();
            HabilitarControles(false, true, false, false, false);
            ListadoEmpleado();
            this.tbEmpleado.SelectedTab = this.tbBusquedaE;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el Código del Empleado", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDni.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el DNI del Empleado", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNombres.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el Nombres del Empleado", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtApellidos.Text.Equals(""))
            {
                MessageBox.Show(null, "Ingrese el Apellido del Empleado", "Sistema de Ventas Botica Saldaña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ActualizarEmpleado();
            Limpiar();
            HabilitarControles(false, true, false, false, false);
            ListadoEmpleado();
            this.tbEmpleado.SelectedTab = this.tbBusquedaE;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarControles(false, true, false, false, false);
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
     if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
    if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            { 
                e.Handled = true;
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tbEmpleado.SelectedTab = this.tbNuevoMod;
            FilaSeleccionada();
            HabilitarControles(true, false, false, true, true);
            txtCodigo.Enabled = true;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (!txtBusqueda.Text.Equals(""))
            {
                int num;

                if (int.TryParse(txtBusqueda.Text, out num))
                {
                    BusquedaEmpleadoByDni(txtBusqueda.Text.Trim());
                }
                else
                {
                    BusquedaEmpleadoByNombres(txtBusqueda.Text.Trim());
                }
             }
            else
            {
                ListadoEmpleado();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewExcel();
        }
    }
}
