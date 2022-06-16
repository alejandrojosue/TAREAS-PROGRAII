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
    public partial class frmFacturas : Form
    {
        public frmFacturas()
        {
            InitializeComponent();
        }
        private PII_2022_II_P1_2021220030.Entities cbcontext = 
            new PII_2022_II_P1_2021220030.Entities();
        private void frmFacturas_Load(object sender, EventArgs e)
        {
            new frmMenu().table(detallesFacturaDataGridView, true);
            new frmMenu().formularios(this);
            cbcontext.Facturas
                .OrderBy(factura => factura.FacturaID)
                .Load();
            facturasBindingSource.DataSource = cbcontext.Facturas.Local;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            new frmMenu().Show();
            Hide();
        }

        private void facturasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            facturasBindingSource.EndEdit();
            try
            {
               cbcontext.SaveChanges();
                MessageBox.Show("Datos registrados exitósamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbEntityValidationException)
            {
                MessageBox.Show("Verifique que todos los campos esten llenos!");
            }
        }

        private void frmFacturas_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnRegresar.PerformClick();

        }
    }
}
