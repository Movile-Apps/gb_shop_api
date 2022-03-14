using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gb_shop_api.Models.Request
{
    public class EventoLimpiezaRequest
    {
        public int IdEvento { get; set; }
        public int? IdPatrocinador { get; set; }
        public int? IdFoto { get; set; }
        public int? IdGeoubicacion { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public int? PersonasRequeridas { get; set; }
        public int? Asistencias { get; set; }
        public FotoRequest FotoRequest { get; set; }
        public PatrocinadorRequest PatrocinadorRequest { get; set; }
        public GeoubicacionRequest GeoubicacionRequest { get; set; }
    }
}
