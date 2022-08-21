using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Table("RESERVACIONES")]
    public partial class Reservacione
    {
        [Key]
        [Column("ID_RESERVACION")]
        public int IdReservacion { get; set; }
        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }
        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }
        [Column("NUMERO_ASIENTO")]
        [Display(Name = "Número de Asiento")]
        public int NumeroAsiento { get; set; }
        [Column("FECHA", TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        [Column("PRECIO", TypeName = "decimal(18, 0)")]
        public decimal Precio { get; set; }
        [Column("ISV", TypeName = "decimal(18, 0)")]
        public decimal Isv { get; set; }
        [Column("DESCUENTO", TypeName = "decimal(18, 0)")]
        public decimal Descuento { get; set; }
        [Column("TOTAL", TypeName = "decimal(18, 0)")]
        public decimal Total { get; set; }

        [ForeignKey("IdCliente")]
        [Display(Name = "Identidad Cliente")]
        [InverseProperty("Reservaciones")]
        public virtual Cliente? IdClienteNavigation { get; set; } = null!;
        [ForeignKey("IdVuelo")]
        [Display(Name = "Destino")]
        [InverseProperty("Reservaciones")]
        [XmlIgnore]
        public virtual Vuelo? IdVueloNavigation { get; set; } = null!;
    }
}
