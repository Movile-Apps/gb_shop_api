using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gb_shop_api.Models.Request
{
    public class FotoRequest
    {
        public int IdFoto { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
    }
}
