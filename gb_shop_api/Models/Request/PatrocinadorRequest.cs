using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gb_shop_api.Models.Request
{
    public class PatrocinadorRequest
    {
        public int IdPadrocinador { get; set; }
        public int? IdFoto { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public FotoRequest FotoRequest { get; set; }
    }
}
