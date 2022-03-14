using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gb_shop_api.Models.Request
{
    public class PoiRequest
    {
        public int IdPoi { get; set; }
        public int? IdReporte { get; set; }
        public int? Confirmaciones { get; set; }
        public int? Negaciones { get; set; }
    }
}
