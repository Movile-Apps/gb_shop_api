using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gb_shop_api.Models.Request
{
    public class GeoubicacionRequest
    {
        public int IdGeoubicacion { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
    }
}
