using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conexion
{
    public partial class frmHistoricoFactura : Form
    {
        public frmHistoricoFactura()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            new frmMenu().Show();
            Hide();
        }

        private void frmHistoricoFactura_Load(object sender, EventArgs e)
        {

            new frmMenu().formularios(this);
            new frmMenu().table(detallesFacturaDataGridView,false);
            dbContext.DetallesFactura.Load();
            detallesFacturaBindingSource.DataSource =
                dbContext.DetallesFactura.Local;
        }
        private PII_2022_II_P1_2021220030.Entities dbContext = new PII_2022_II_P1_2021220030.Entities();
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            detallesFacturaBindingSource.DataSource =
                dbContext.DetallesFactura.Local
                .Where(detalle=>detalle.FacturaID == int.Parse(txtIdFactura.Text));
            //var detallesFactura =
            //    from facturas in dbContext.Facturas
            //    from detalles in dbContext.DetallesFactura
            //    orderby detalles.DetalleFacturaID, facturas.FacturaID
            //    select new { facturas.ClienteID, facturas.EmpleadoID, facturas.FechaIngreso, detalles.ProductoID, detalles.Nombre, detalles.Cantidad, detalles.SubTotal, facturas.ISV, facturas.Descuento, facturas.TotalPagar };
            //foreach (var detalleFactura in detallesFactura)
            //{
                
            //}
        }

        private void frmHistoricoFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnRegresar.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbContext.DetallesFactura.Load();
            detallesFacturaBindingSource.DataSource =
                dbContext.DetallesFactura.Local;
        }

    }
}
