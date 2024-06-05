namespace Compras.Domain.Entidades
{
    public class OrdenProducto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int IdOrdenCompra { get; set; }
        public int IdProducto { get; set; }

        public OrdenDeCompra OrdenCompra { get; set; }
        public Producto Producto { get; set; }

    }
}
