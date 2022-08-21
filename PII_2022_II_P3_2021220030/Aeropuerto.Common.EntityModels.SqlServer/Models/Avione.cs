using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Table("AVIONES")]
    public partial class Avione
    {
        public Avione()
        {
            Vuelos = new HashSet<Vuelo>();
        }

        [Key]
        [Column("ID_AVION")]
        public int IdAvion { get; set; }
        [Column("CAPACIDAD")]
        public int Capacidad { get; set; }
        [Column("LONGITUD")]
        [StringLength(12)]
        [Unicode(false)]
        public string Longitud { get; set; } = null!;
        [Column("ENVERGADURA")]
        [StringLength(12)]
        [Unicode(false)]
        public string Envergadura { get; set; } = null!;
        [Column("VELOCIDAD")]
        [StringLength(12)]
        [Unicode(false)]
        public string Velocidad { get; set; } = null!;
        [Column("COMPANIA")]
        [StringLength(12)]
        [Unicode(false)]
        [Display(Name = "Compañía")]
        public string Compania { get; set; } = null!;
        [Column("NUMERO")]
        [Display(Name = "Número de Avión")]
        public int Numero { get; set; }
        [Column("FECHADQUISICION", TypeName = "datetime")]
        [Display(Name = "Fecha de Adquisición")]
        [DataType(DataType.Date)]
        public DateTime Fechadquisicion { get; set; }

        [InverseProperty("IdAvionNavigation")]
        //[InverseProperty(nameof(Vuelo.IdAvionNavigation))]
        [XmlIgnore]
        public virtual ICollection<Vuelo> Vuelos { get; set; }
    }
}
