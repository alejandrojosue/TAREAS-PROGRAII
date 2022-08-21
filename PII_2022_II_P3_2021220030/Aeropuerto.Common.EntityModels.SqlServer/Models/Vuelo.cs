using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Table("VUELOS")]
    public partial class Vuelo
    {
        public Vuelo()
        {
            Reservaciones = new HashSet<Reservacione>();
        }

        [Key]
        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }
        [Column("HORARIOSALIDA", TypeName = "datetime")]
        [Display(Name = "Horario de Salida")]
        public DateTime Horariosalida { get; set; }
        [Column("HORARIOLLEGADA", TypeName = "datetime")]
        [Display(Name = "Horario de Llegada")]
        public DateTime Horariollegada { get; set; }
        [Column("ORIGEN")]
        [StringLength(15)]
        [Unicode(false)]
        public string Origen { get; set; } = null!;
        [Column("DESTINO")]
        [StringLength(15)]
        [Unicode(false)]
        public string Destino { get; set; } = null!;

        [Column("ID_AVION")]
        [Display(Name = "Número de Avión")]
        public int IdAvion { get; set; }
        [Column("ID_PILOTO")]
        [Display(Name = "Piloto")]
        public int IdPiloto { get; set; }

        [ForeignKey("IdAvion")]
        [InverseProperty(nameof(Avione.Vuelos))]
        //[InverseProperty("Vuelos")]
        [Display(Name = "Número de Avión")]
        public virtual Avione? IdAvionNavigation { get; set; } = null!;
        [ForeignKey("IdPiloto")]
        [InverseProperty("Vuelos")]
        //[InverseProperty(nameof(Usuario.Vuelos))]

        [Display(Name = "Piloto")]
        public virtual Usuario? IdPilotoNavigation { get; set; } = null!;
        [InverseProperty("IdVueloNavigation")]

        [XmlIgnore]
        public virtual ICollection<Reservacione> Reservaciones { get; set; }
    }
}
