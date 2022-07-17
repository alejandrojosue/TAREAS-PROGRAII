using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    public partial class Servicio
    {
        public Servicio()
        {
            DetallesFacturas = new HashSet<DetallesFactura>();
        }

        [Key]
        public int ServiciosId { get; set; }
        [Column(TypeName = "NVARCHAR (25)")]
    [StringLength(25)]
        [Required]
        public string Nombre { get; set; } = null!;
        [Column(TypeName = "NVARCHAR (35)")]
    [StringLength(35)]
        public string? Descripcion { get; set; }
        [Column(TypeName = "MONEY")]
        public decimal? Costo { get; set; }
        [Column(TypeName = "MONEY")]
        public decimal? Precio { get; set; }

        [InverseProperty("Servicios")]
        public virtual ICollection<DetallesFactura> DetallesFacturas { get; set; }
    }
}
