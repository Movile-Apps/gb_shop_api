using System;
using System.Collections.Generic;

#nullable disable

namespace gb_shop_api.Models.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reportes = new HashSet<Reporte>();
        }

        public int IdUsuario { get; set; }
        public int? IdFoto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public virtual Foto IdFotoNavigation { get; set; }
        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
