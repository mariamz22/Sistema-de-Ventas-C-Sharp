using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocio;
using capaEntidades;

namespace capaPresentacion
{
    public partial class FrmAcceso : Form
    {
        public FrmAcceso()
        {
            InitializeComponent();
        }

        private void FrmAcceso_Load(object sender, EventArgs e)
        {
            txtUsuario.Select();
        }
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            txtUsuario.BackColor = Color.Azure;
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            txtUsuario.BackColor = Color.White;
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            txtPass.BackColor = Color.Azure;
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            txtPass.BackColor = Color.White;
        }

        private void Ingresar()
        {
            if (!txtUsuario.Text.Equals("") && !txtPass.Text.Equals(""))
            {
                CNLogin objAccesoUsuario = new CNLogin();
                CEUsuario objLogin = new CEUsuario();
                objLogin.Usuario = txtUsuario.Text.Trim();
                objLogin.Password = txtPass.Text.Trim();
                Hide();
                FrmMenuPrincipal menu = new FrmMenuPrincipal();
                menu.Show();

            }
            else
            {
                MessageBox.Show(null, "Ingrese el usuario y contraseña", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Ingresar();
            }
        }

       
    }
}
