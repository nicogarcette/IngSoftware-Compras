using System.ComponentModel.DataAnnotations;

namespace Compras.Aplication.Dtos.Request
{
    public class OrdenCompraRequest
    {
        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        public int IdProveedor { get; set; }
        public List<OrdenProductoDto> Productos { get; set; }
    }
}
