using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiAlmacen.Models
{
    public partial class Transaccione
    {
        public int Idtransaccion { get; set; }
        public string TipoTransaccion { get; set; }
        public int? Idproducto { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaTransaccion { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public virtual Producto IdproductoNavigation { get; set; }
    }
}
