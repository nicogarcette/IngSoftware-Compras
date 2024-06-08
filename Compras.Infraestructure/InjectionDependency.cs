using Compras.Aplication.Interfaces.IRepositories;
using Compras.Infraestructure.Persistence;
using Compras.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Compras.Infraestructure
{
    public static class InjectionDependency
    {

        public static void AddInfraestructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionDB"));
            });


            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IOrdenCompraRepository, OrdenCompraRepository>();
        }
    }
}
