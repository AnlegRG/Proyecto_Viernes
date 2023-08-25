using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiAlmacen.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Transacciones = new HashSet<Transaccione>();
        }

        public int Idproducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public int? CantidadEnStock { get; set; }

        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
