using System;
using System.Collections.Generic;

namespace PERSEO.Models
{
    public partial class Factura
    {
        public int Factura1 { get; set; }
        public int Vendedor { get; set; }
        public string Cliente { get; set; } = null!;
        public int Producto { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public virtual Cliente ClienteNavigation { get; set; } = null!;
        public virtual Producto ProductoNavigation { get; set; } = null!;
        public virtual Vendedor VendedorNavigation { get; set; } = null!;
    }
}
