using System;
using System.Collections.Generic;

namespace PERSEO.Models
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            Facturas = new HashSet<Factura>();
            Locales = new HashSet<Locale>();
        }

        public int CodigoVendedor { get; set; }
        public string Dni { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Direccion { get; set; }
        public string Email { get; set; } = null!;

        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Locale> Locales { get; set; }
    }
}
