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
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }
        private PII_2022_II_P1_2021220030.Entities dbContext = new PII_2022_II_P1_2021220030.Entities();

        private void pnlFondo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void puestoLabel_Click(object sender, EventArgs e)
        {

        }

        private void fechaIngresoLabel_Click(object sender, EventArgs e)
        {

        }

        private void codigoLabel_Click(object sender, EventArgs e)
        {

        }

        private void nombreLabel_Click(object sender, EventArgs e)
        {

        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            new frmMenu().table(empleadosDataGridView, true);
            new frmMenu().formularios(this);
            dbContext.Empleados
                .OrderBy(empleado => empleado.Nombre)
                .Load();

            empleadosBindingSource.DataSource = dbContext.Empleados.Local;
        }

        private void empleadosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            empleadosBindingSource.EndEdit();
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

        private void empleadosBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void frmEmpleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnRegresar.PerformClick();

        }
    }
}
