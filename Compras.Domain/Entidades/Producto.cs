namespace Compras.Domain.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int NumeroLote { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdProveedor { get; set; }

        public Proveedor Proveedor { get; set; }
        public IEnumerable<OrdenProducto> OrdenProductos { get; set; }
    }
}
