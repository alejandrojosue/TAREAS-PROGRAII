using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Table("DetallesFactura")]
    public partial class DetallesFactura
    {
        [Key]
        public int DetallesFacturaId { get; set; }
        public int? FacturasId { get; set; }
        public int? ServiciosId { get; set; }

        [ForeignKey("FacturasId")]
        [InverseProperty("DetallesFacturas")]
        public virtual Factura? Facturas { get; set; }
        [ForeignKey("ServiciosId")]
        [InverseProperty("DetallesFacturas")]
        public virtual Servicio? Servicios { get; set; }
    }
}
