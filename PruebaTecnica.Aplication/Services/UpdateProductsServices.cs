using PruebaTecnica.Aplication.DTOs;
using PruebaTecnica.Aplication.Services.Interface.Services;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces.Repositories;
using Domain.Common.Response;

namespace PruebaTecnica.Aplication.Services
{
    public class UpdateProductsServices : IUpdateProductsServices
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductsServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<BaseResponse<int>> Update(UpdateProductRequest request)
        {
            try
            {
                if (request == null) return BaseResponse<int>.BadRequest("Error en los datos enviado para actualizar");
                var productUpdate = await _productRepository.UpdateProduct(request.IdProduct);
                if (productUpdate == null) return BaseResponse<int>.BadRequest("El producto no existe");

                productUpdate.Name = request.Name;
                productUpdate.Description = request.Description;
                productUpdate.Price = request.Price;
                productUpdate.Observation = "Actualización de producto";
                productUpdate.CreatedAt = DateTime.Now;

                _productRepository.Update(productUpdate);
                var result = await _productRepository.SaveChangesAsync();
                if (result == 0) return BaseResponse<int>.BadRequest($"{request.Name} no se puede actualziar");
                return BaseResponse<int>.Ok(result, "Actualizació exitosa");
            }
            catch (Exception ex)
            {
                return BaseResponse<int>.BadRequest(ex.Message);
            }
        }
    }
}
