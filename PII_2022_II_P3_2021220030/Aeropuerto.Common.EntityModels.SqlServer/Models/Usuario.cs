using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Table("USUARIOS")]
    public partial class Usuario
    {
        public Usuario()
        {
            Vuelos = new HashSet<Vuelo>();
        }

        [Key]
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }
        [Column("NOMBRE")]
        [StringLength(20)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [Column("APELLIDO")]
        [StringLength(20)]
        [Unicode(false)]
        public string Apellido { get; set; } = null!;
        [Column("USUARIO")]
        [StringLength(12)]
        [Unicode(false)]
        [Display(Name = "Usuario")]
        public string Usuario1 { get; set; } = null!;
        [Column("CLAVE")]
        [StringLength(12)]
        [Unicode(false)]
        public string Clave { get; set; } = null!;
        [Column("ID_CARGO")]
        public int IdCargo { get; set; }
        [Column("DIRECCION")]
        [StringLength(150)]
        [Unicode(false)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; } = null!;
        [Column("TELEFONO")]
        [StringLength(15)]
        [Unicode(false)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; } = null!;

        [ForeignKey("IdCargo")]
        [InverseProperty("Usuarios")]
        [Display(Name = "Cargo")]
        public virtual Cargo? IdCargoNavigation { get; set; } = null!;
        [InverseProperty("IdPilotoNavigation")]
        [Display(Name = "Piloto")]
        [XmlIgnore]
        public virtual ICollection<Vuelo> Vuelos { get; set; }
    }
}
