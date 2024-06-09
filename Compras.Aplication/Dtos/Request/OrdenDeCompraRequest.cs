using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compras.Aplication.Dtos.Request
{
    public class OrdenDeCompraRequest
    {
        public string Descripcion { get; set; }
        public int? PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProveedor { get; set; }

    }
}
