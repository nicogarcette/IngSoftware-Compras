namespace Compras.Domain.Entidades
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public int Cuil { get; set; }
        public string NombreEmpresa { get; set; }

        public IEnumerable<Producto> Productos { get; set; }
        public IEnumerable<OrdenDeCompra> OrdenesDeCompra { get; set; }

    }
}
