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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }
        private PII_2022_II_P1_2021220030.Entities dbContext =
            new PII_2022_II_P1_2021220030.Entities();
        private void productosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            productosBindingSource.EndEdit();
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

        private void frmProductos_Load(object sender, EventArgs e)
        {
            new frmMenu().table(productosDataGridView, false);
            dbContext.Productos
                 .OrderBy(producto => producto.Nombre)
                 .Load();

            productosBindingSource.DataSource = dbContext.Productos.Local;
        }

        private void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnRegresar.PerformClick();

        }
    }
}
