namespace Compras.Aplication.Dtos
{
    public class OrdenDeCompraDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
        public ProveedorDto Proveedor { get; set; }
        public List<ProductoDto> Productos { get; set; }
    }
}
