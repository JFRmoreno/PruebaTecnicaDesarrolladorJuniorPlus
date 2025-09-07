using PruebaTecnica.Aplication.DTOs;
using PruebaTecnica.Aplication.Services.Interface.Services;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces.Repositories;
using Domain.Common.Response;

namespace PruebaTecnica.Aplication.Services
{
    public class CreateProductsServices : ICreateProductsServices
    {
        private readonly IProductRepository _productRepository;

        public CreateProductsServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<BaseResponse<int>> Create(CreateProductsRequest request)
        {
            try
            {
                if (request == null) return BaseResponse<int>.BadRequest("Error en los datos enviado");
                var productExist = await _productRepository.GetToProduct(request.Name);
                if (productExist != null) return BaseResponse<int>.BadRequest("El producto enviado ya existe");

                var productCreate = new Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    CreatedAt = DateTime.Now,
                    Isactive = true,
                    Observation = "Creacion de Producto"
                };

                await _productRepository.AddAsync(productCreate);
                var result = await  _productRepository.SaveChangesAsync();
                if (result == 0) return BaseResponse<int>.BadRequest($"{request.Name} no se puede guardar");
                return BaseResponse<int>.Ok(result,"Creacion exitosa");
            }
            catch (Exception ex) 
            {
                return BaseResponse<int>.BadRequest(ex.Message);
            }
        }
    }
}
