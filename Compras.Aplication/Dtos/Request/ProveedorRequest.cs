using System.ComponentModel.DataAnnotations;

namespace Compras.Aplication.Dtos.Request
{
    public class ProveedorRequest
    {
        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Telefono es obligatorio.")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "La Direccion es obligatoria.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Cuil es obligatorio.")]
        public int Cuil { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        public string NombreEmpresa { get; set; }
    }
}
