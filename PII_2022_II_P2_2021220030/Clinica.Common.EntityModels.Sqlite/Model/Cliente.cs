using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        [Key]
        public int ClientesId { get; set; }
        [RegularExpression("[A-Z]{5}")] //Solo sean letras
        [Column(TypeName = "nvarchar (25)")]
    [StringLength(25)]
        public string? Nombre { get; set; }
        [RegularExpression("[A-Z]{5}")] //Solo sean letras
        [Column(TypeName = "nvarchar (25)")]
    [StringLength(25)]
        public string? Apellido { get; set; }
        [Column(TypeName = "nvarchar (13)")]
        [Required]
        public string Identidad { get; set; } = null!;
        [Column(TypeName = "nvarchar (120)")]
    [StringLength(120)]
        public string? Direccion { get; set; }
        [Column(TypeName = "nvarchar (10)")]
    [StringLength(10)]
        public string? Telefono { get; set; }
        [Column(TypeName = "int")]
        public int Edad { get; set; }

        [InverseProperty("Clientes")]
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
