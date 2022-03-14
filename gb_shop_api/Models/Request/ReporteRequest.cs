using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gb_shop_api.Models.Request
{
    public class ReporteRequest
    {
        public int IdReporte { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEtiqueta { get; set; }
        public int? IdFoto { get; set; }
        public int? IdGeoubicacion { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Usuario { get; set; }
        public string Etiqueta { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public string Nombre_Foto { get; set; }
        public string Url_Foto { get; set; }
    }
}
