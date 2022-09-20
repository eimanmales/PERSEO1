using System;
using System.Collections.Generic;

namespace PERSEO.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public string Dni { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Direccion { get; set; }
        public string Email { get; set; } = null!;

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
