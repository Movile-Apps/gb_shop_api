using System;
using System.Collections.Generic;

#nullable disable

namespace gb_shop_api.Models.Data
{
    public partial class Poi
    {
        public int IdPoi { get; set; }
        public int? IdReporte { get; set; }
        public int? Confirmaciones { get; set; }
        public int? Negaciones { get; set; }

        public virtual Reporte IdReporteNavigation { get; set; }
    }
}
