using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Table("CLIENTES")]
    public partial class Cliente
    {
        public Cliente()
        {
            Reservaciones = new HashSet<Reservacione>();
        }

        [Key]
        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }
        [Column("NOMBRE")]
        [StringLength(20)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [Column("APELLIDO")]
        [StringLength(20)]
        [Unicode(false)]
        public string Apellido { get; set; } = null!;
        [Column("DIRECCION")]
        [StringLength(150)]
        [Display(Name = "Dirección")]
        [Unicode(false)]
        public string Direccion { get; set; } = null!;
        [Column("TELEFONO")]
        [StringLength(15)]
        [Unicode(false)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; } = null!;
        [Column("IDENTIDAD")]
        [StringLength(15)]
        [Unicode(false)]
        public string Identidad { get; set; } = null!;
        [Column("FECHANAC", TypeName = "datetime")]
        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime Fechanac { get; set; }

        [InverseProperty("IdClienteNavigation")]
        [XmlIgnore]
        public virtual ICollection<Reservacione> Reservaciones { get; set; }
    }
}
