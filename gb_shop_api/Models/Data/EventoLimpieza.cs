using System;
using System.Collections.Generic;

#nullable disable

namespace gb_shop_api.Models.Data
{
    public partial class EventoLimpieza
    {
        public int IdEvento { get; set; }
        public int? IdPatrocinador { get; set; }
        public int? IdFoto { get; set; }
        public int? IdGeoubicacion { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public int? PersonasRequeridas { get; set; }
        public int? Asistencias { get; set; }

        public virtual Foto IdFotoNavigation { get; set; }
        public virtual Geoubicacion IdGeoubicacionNavigation { get; set; }
        public virtual Patrocinador IdPatrocinadorNavigation { get; set; }
    }
}
