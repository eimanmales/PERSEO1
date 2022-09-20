using System;
using System.Collections.Generic;

namespace PERSEO.Models
{
    public partial class Locale
    {
        public int Movimiento { get; set; }
        public int NLocal { get; set; }
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int CodigoProducto { get; set; }
        public int Vendedor { get; set; }

        public virtual Producto CodigoProductoNavigation { get; set; } = null!;
        public virtual Vendedor VendedorNavigation { get; set; } = null!;
    }
}
