using Compras.Aplication.Interfaces.IServices;
using Compras.Aplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Compras.Aplication
{
    public static class InjectionDepency
    {

        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IOrdenCompraService, OrdenCompraService>();
        }
    }
}
