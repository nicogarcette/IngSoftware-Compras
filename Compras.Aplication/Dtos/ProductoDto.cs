namespace Compras.Aplication.Dtos
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int NumeroLote { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
