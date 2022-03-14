using System;
using System.Collections.Generic;

#nullable disable

namespace gb_shop_api.Models.Data
{
    public partial class Geoubicacion
    {
        public Geoubicacion()
        {
            EventoLimpiezas = new HashSet<EventoLimpieza>();
            Reportes = new HashSet<Reporte>();
        }

        public int IdGeoubicacion { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual ICollection<EventoLimpieza> EventoLimpiezas { get; set; }
        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
