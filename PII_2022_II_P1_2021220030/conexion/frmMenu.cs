using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conexion
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        public void table(DataGridView dt, bool habilitado)
        {
            dt.BackgroundColor = pnlFondo.BackColor;
            dt.Enabled = habilitado;
            dt.BorderStyle = BorderStyle.None;
            dt.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            dt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dt.ForeColor = Color.Black;
        }

        public void formularios(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            new frmFacturas().Show();
            Hide();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            new frmProductos().Show();
            Hide();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            new frmClientes().Show();
            Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            new frmEmpleados().Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmHistoricoFactura().Show();
            Hide();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
