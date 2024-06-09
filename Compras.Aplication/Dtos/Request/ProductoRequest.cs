namespace Compras.Aplication.Dtos.Request
{
    public class ProductoRequest
    {
        public string Descripcion { get; set; }
        public double PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int NumeroLote { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdProveedor { get; set; }
    }
}
