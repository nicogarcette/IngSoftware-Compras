﻿namespace Compras.Aplication.Dtos.Request
{
    public class OrdenCompraRequest
    {
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProveedor { get; set; }
    }
}
