//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PII_2022_II_P1_2021220030
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetallesFactura
    {
        public int DetalleFacturaID { get; set; }
        public int FacturaID { get; set; }
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
    
        public virtual Productos Productos { get; set; }
        public virtual Facturas Facturas { get; set; }
    }
}
