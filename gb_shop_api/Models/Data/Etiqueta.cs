using System;
using System.Collections.Generic;

#nullable disable

namespace gb_shop_api.Models.Data
{
    public partial class Etiqueta
    {
        public Etiqueta()
        {
            Reportes = new HashSet<Reporte>();
        }

        public int IdEtiqueta { get; set; }
        public int? IdFoto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual Foto IdFotoNavigation { get; set; }
        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
