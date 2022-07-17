using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    public partial class Factura
    {
        public Factura()
        {
            DetallesFacturas = new HashSet<DetallesFactura>();
        }

        [Key]
        public int FacturasId { get; set; }
        [Column(TypeName = "INT")]
        public int? ClientesId { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime? Fecha { get; set; }
        [Column(TypeName = "MONEY")]
        public decimal? Subtotal { get; set; }
        [Column(TypeName = "MONEY")]
        public decimal? Total { get; set; }
        [Column("ISV", TypeName = "MONEY")]
        public decimal? Isv { get; set; }
        [Column(TypeName = "MONEY")]
        public decimal? Descuento { get; set; }

        [ForeignKey("ClientesId")]
        [InverseProperty("Facturas")]
        public virtual Cliente? Clientes { get; set; }
        [InverseProperty("Facturas")]
        public virtual ICollection<DetallesFactura> DetallesFacturas { get; set; }
    }
}
