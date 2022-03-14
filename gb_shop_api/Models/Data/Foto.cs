using System;
using System.Collections.Generic;

#nullable disable

namespace gb_shop_api.Models.Data
{
    public partial class Foto
    {
        public Foto()
        {
            Etiqueta = new HashSet<Etiqueta>();
            EventoLimpiezas = new HashSet<EventoLimpieza>();
            Patrocinadors = new HashSet<Patrocinador>();
            Reportes = new HashSet<Reporte>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdFoto { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Etiqueta> Etiqueta { get; set; }
        public virtual ICollection<EventoLimpieza> EventoLimpiezas { get; set; }
        public virtual ICollection<Patrocinador> Patrocinadors { get; set; }
        public virtual ICollection<Reporte> Reportes { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
