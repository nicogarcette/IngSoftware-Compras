namespace Compras.Domain.Entidades
{
    public class OrdenDeCompra
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProveedor { get; set; }

        public Proveedor Proveedor { get; set; }
        public IEnumerable<OrdenProducto> OrdenProductos { get; set; }
    }
}
