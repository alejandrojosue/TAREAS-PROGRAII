using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conexion
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }
        private PII_2022_II_P1_2021220030.Entities dbContext = new PII_2022_II_P1_2021220030.Entities();

        private void frmClientes_Load(object sender, EventArgs e)
        {
            new frmMenu().table(clientesDataGridView, false);
            new frmMenu().formularios(this);
            dbContext.Clientes
                .OrderBy(cliente => cliente.Nombre)
                .Load();

            clientesBindingSource.DataSource = dbContext.Clientes.Local;
        }

        private void clientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            clientesBindingSource.EndEdit();
            try
            {
                dbContext.SaveChanges();
                MessageBox.Show("Datos registrados exitósamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbEntityValidationException)
            {
                MessageBox.Show("Verifique que todos los campos esten llenos!");
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            new frmMenu().Show();
            Hide();
        }

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnRegresar.PerformClick();

        }
    }
}
