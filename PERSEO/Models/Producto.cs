using System;
using System.Collections.Generic;

namespace PERSEO.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Facturas = new HashSet<Factura>();
            Locales = new HashSet<Locale>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Locale> Locales { get; set; }
    }
}
