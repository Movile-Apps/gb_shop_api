using System;
using System.Collections.Generic;

#nullable disable

namespace gb_shop_api.Models.Data
{
    public partial class Patrocinador
    {
        public Patrocinador()
        {
            EventoLimpiezas = new HashSet<EventoLimpieza>();
        }

        public int IdPadrocinador { get; set; }
        public int? IdFoto { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public virtual Foto IdFotoNavigation { get; set; }
        public virtual ICollection<EventoLimpieza> EventoLimpiezas { get; set; }
    }
}
