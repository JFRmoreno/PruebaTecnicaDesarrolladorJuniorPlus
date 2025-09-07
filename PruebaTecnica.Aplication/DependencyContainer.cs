using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Aplication.Services;
using PruebaTecnica.Aplication.Services.Interface.Services;
using PruebaTecnica.Domain.Interfaces.Repositories;

namespace PruebaTecnica.Aplication
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration configuration)
        {


            #region Services
            services.AddTransient<IGetListProductServices, GetListProductServices>();
            services.AddTransient<ICreateProductsServices, CreateProductsServices>();
            services.AddTransient<IUpdateProductsServices, UpdateProductsServices>();
            services.AddTransient<IDeleteProductsServices, DeleteProductsServices>();
            #endregion

            return services;

        }
    }
}
