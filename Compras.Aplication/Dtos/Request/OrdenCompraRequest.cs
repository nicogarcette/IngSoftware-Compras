namespace Compras.Aplication.Dtos.Request
{
    public class OrdenCompraRequest
    {
        //atributos
        public string Descripcion { get; set; }
        public int? PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProveedor { get; set; }

    }
}
