using System.ComponentModel.DataAnnotations;

namespace Compras.Aplication.Dtos.Request
{
    public class ProductoRequest
    {
        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "EL PrecioVenta es obligatorio.")]
        public double PrecioVenta { get; set; }

        [Required(ErrorMessage = "El StockActual es obligatorio.")]
        public int StockActual { get; set; }

        [Required(ErrorMessage = "El stock minimo es obligatorio.")]
        public int StockMinimo { get; set; }

        [Required(ErrorMessage = "EL lote es obligatorio.")]
        public int NumeroLote { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime FechaVencimiento { get; set; }

        [Required(ErrorMessage = "El proveedor es obligatorio.")]
        public int IdProveedor { get; set; }
    }
}
