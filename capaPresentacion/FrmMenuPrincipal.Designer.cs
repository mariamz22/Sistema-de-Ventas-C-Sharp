namespace capaPresentacion
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stsBarraPrincipal = new System.Windows.Forms.StatusStrip();
            this.tsslUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslNombre = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslServidor = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslBaseDatos = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnsOpciones = new System.Windows.Forms.MenuStrip();
            this.catálogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsEmpleado = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AjustesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.devolucionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impresiónEtiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devolucionesClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasPorProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kardexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reimpresiónDeFacturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesPremierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaDiariaPorProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stsBarraPrincipal.SuspendLayout();
            this.mnsOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsBarraPrincipal
            // 
            this.stsBarraPrincipal.BackColor = System.Drawing.Color.White;
            this.stsBarraPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslUsuario,
            this.tsslNombre,
            this.tsslServidor,
            this.tsslBaseDatos});
            this.stsBarraPrincipal.Location = new System.Drawing.Point(0, 343);
            this.stsBarraPrincipal.Name = "stsBarraPrincipal";
            this.stsBarraPrincipal.Size = new System.Drawing.Size(739, 24);
            this.stsBarraPrincipal.TabIndex = 5;
            this.stsBarraPrincipal.Text = "statusStrip1";
            this.stsBarraPrincipal.Visible = false;
            // 
            // tsslUsuario
            // 
            this.tsslUsuario.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslUsuario.Name = "tsslUsuario";
            this.tsslUsuario.Size = new System.Drawing.Size(50, 19);
            this.tsslUsuario.Text = "usuario";
            // 
            // tsslNombre
            // 
            this.tsslNombre.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslNombre.Name = "tsslNombre";
            this.tsslNombre.Size = new System.Drawing.Size(55, 19);
            this.tsslNombre.Text = "Nombre";
            // 
            // tsslServidor
            // 
            this.tsslServidor.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslServidor.Name = "tsslServidor";
            this.tsslServidor.Size = new System.Drawing.Size(53, 19);
            this.tsslServidor.Text = "servidor";
            // 
            // tsslBaseDatos
            // 
            this.tsslBaseDatos.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslBaseDatos.Name = "tsslBaseDatos";
            this.tsslBaseDatos.Size = new System.Drawing.Size(67, 19);
            this.tsslBaseDatos.Text = "base datos";
            // 
            // mnsOpciones
            // 
            this.mnsOpciones.BackColor = System.Drawing.Color.White;
            this.mnsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catálogosToolStripMenuItem,
            this.entradasToolStripMenuItem,
            this.ventasToolStripMenuItem});
            this.mnsOpciones.Location = new System.Drawing.Point(0, 0);
            this.mnsOpciones.Name = "mnsOpciones";
            this.mnsOpciones.Size = new System.Drawing.Size(739, 24);
            this.mnsOpciones.TabIndex = 4;
            this.mnsOpciones.Text = "Menú de Opciones";
            // 
            // catálogosToolStripMenuItem
            // 
            this.catálogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsProductos,
            this.tmsEmpleado,
            this.proveedoresToolStripMenuItem});
            this.catálogosToolStripMenuItem.Name = "catálogosToolStripMenuItem";
            this.catálogosToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.catálogosToolStripMenuItem.Text = "Administración";
            // 
            // tmsProductos
            // 
            this.tmsProductos.Name = "tmsProductos";
            this.tmsProductos.Size = new System.Drawing.Size(180, 22);
            this.tmsProductos.Text = "Clientes";
            this.tmsProductos.Click += new System.EventHandler(this.tmsClientes_Click);
            // 
            // tmsEmpleado
            // 
            this.tmsEmpleado.Name = "tmsEmpleado";
            this.tmsEmpleado.Size = new System.Drawing.Size(180, 22);
            this.tmsEmpleado.Text = "Empleados";
            this.tmsEmpleado.Click += new System.EventHandler(this.tmsEmpleados_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.tmsProveedores_Click);
            // 
            // entradasToolStripMenuItem
            // 
            this.entradasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productoToolStripMenuItem,
            this.AjustesToolStripMenuItem1,
            this.devolucionesToolStripMenuItem,
            this.impresiónEtiquetasToolStripMenuItem,
            this.devolucionesClienteToolStripMenuItem});
            this.entradasToolStripMenuItem.Name = "entradasToolStripMenuItem";
            this.entradasToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.entradasToolStripMenuItem.Text = "Almacén";
            // 
            // productoToolStripMenuItem
            // 
            this.productoToolStripMenuItem.Name = "productoToolStripMenuItem";
            this.productoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.productoToolStripMenuItem.Text = "Productos";
            this.productoToolStripMenuItem.Click += new System.EventHandler(this.tmsProductos_Click);
            // 
            // AjustesToolStripMenuItem1
            // 
            this.AjustesToolStripMenuItem1.Name = "AjustesToolStripMenuItem1";
            this.AjustesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.AjustesToolStripMenuItem1.Text = "Categorias";
            this.AjustesToolStripMenuItem1.Click += new System.EventHandler(this.tmsCategorias_Click);
            // 
            // devolucionesToolStripMenuItem
            // 
            this.devolucionesToolStripMenuItem.Name = "devolucionesToolStripMenuItem";
            this.devolucionesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.devolucionesToolStripMenuItem.Text = "Presentacion";
            this.devolucionesToolStripMenuItem.Click += new System.EventHandler(this.tmsPresentacion_Click);
            // 
            // impresiónEtiquetasToolStripMenuItem
            // 
            this.impresiónEtiquetasToolStripMenuItem.Name = "impresiónEtiquetasToolStripMenuItem";
            this.impresiónEtiquetasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.impresiónEtiquetasToolStripMenuItem.Text = "Laboratorio";
            this.impresiónEtiquetasToolStripMenuItem.Click += new System.EventHandler(this.tmsLaboratorio_Click);
            // 
            // devolucionesClienteToolStripMenuItem
            // 
            this.devolucionesClienteToolStripMenuItem.Name = "devolucionesClienteToolStripMenuItem";
            this.devolucionesClienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.devolucionesClienteToolStripMenuItem.Text = "Lote";
            this.devolucionesClienteToolStripMenuItem.Click += new System.EventHandler(this.tmsLote_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.ventasToolStripMenuItem.Text = "Movimientos";
            // 
            // registroToolStripMenuItem
            // 
            this.registroToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            this.registroToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.registroToolStripMenuItem.Text = "Compras";
            this.registroToolStripMenuItem.Click += new System.EventHandler(this.tmsCompras_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem1,
            this.ventasPorProductoToolStripMenuItem,
            this.kardexToolStripMenuItem,
            this.reimpresiónDeFacturasToolStripMenuItem,
            this.clientesPremierToolStripMenuItem,
            this.ventaDiariaPorProductoToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reportesToolStripMenuItem.Text = "Ventas";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.tmsVentas_Click);
            // 
            // ventasToolStripMenuItem1
            // 
            this.ventasToolStripMenuItem1.Name = "ventasToolStripMenuItem1";
            this.ventasToolStripMenuItem1.Size = new System.Drawing.Size(67, 22);
            // 
            // ventasPorProductoToolStripMenuItem
            // 
            this.ventasPorProductoToolStripMenuItem.Name = "ventasPorProductoToolStripMenuItem";
            this.ventasPorProductoToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // kardexToolStripMenuItem
            // 
            this.kardexToolStripMenuItem.Name = "kardexToolStripMenuItem";
            this.kardexToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // reimpresiónDeFacturasToolStripMenuItem
            // 
            this.reimpresiónDeFacturasToolStripMenuItem.Name = "reimpresiónDeFacturasToolStripMenuItem";
            this.reimpresiónDeFacturasToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // clientesPremierToolStripMenuItem
            // 
            this.clientesPremierToolStripMenuItem.Name = "clientesPremierToolStripMenuItem";
            this.clientesPremierToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // ventaDiariaPorProductoToolStripMenuItem
            // 
            this.ventaDiariaPorProductoToolStripMenuItem.Name = "ventaDiariaPorProductoToolStripMenuItem";
            this.ventaDiariaPorProductoToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 367);
            this.Controls.Add(this.stsBarraPrincipal);
            this.Controls.Add(this.mnsOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = ".:: BOTICA ::.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.stsBarraPrincipal.ResumeLayout(false);
            this.stsBarraPrincipal.PerformLayout();
            this.mnsOpciones.ResumeLayout(false);
            this.mnsOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsBarraPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel tsslUsuario;
        private System.Windows.Forms.ToolStripStatusLabel tsslNombre;
        private System.Windows.Forms.ToolStripStatusLabel tsslServidor;
        private System.Windows.Forms.ToolStripStatusLabel tsslBaseDatos;
        private System.Windows.Forms.MenuStrip mnsOpciones;
        private System.Windows.Forms.ToolStripMenuItem catálogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmsProductos;
        private System.Windows.Forms.ToolStripMenuItem tmsEmpleado;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AjustesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem devolucionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impresiónEtiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devolucionesClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ventasPorProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kardexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reimpresiónDeFacturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesPremierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaDiariaPorProductoToolStripMenuItem;
    }
}