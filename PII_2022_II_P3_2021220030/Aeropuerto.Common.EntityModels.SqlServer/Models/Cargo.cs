using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Table("CARGOS")]
    public partial class Cargo
    {
        public Cargo()
        {
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        [Column("ID_CARGO")]
        public int IdCargo { get; set; }
        [Column("NOMBRE")]
        [StringLength(20)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;

        [InverseProperty("IdCargoNavigation")]
        [XmlIgnore]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
