using PruebaTecnica.Aplication.DTOs;
using PruebaTecnica.Aplication.Services.Interface.Services;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces.Repositories;
using Domain.Common.Response;

namespace PruebaTecnica.Aplication.Services
{
    public class DeleteProductsServices : IDeleteProductsServices
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductsServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<BaseResponse<int>> Delete(DeleteProductsRequest request)
        {
            try
            {
                if (request == null) return BaseResponse<int>.BadRequest("Error en los datos enviado para Eliminar");
                var productDelete = await _productRepository.UpdateProduct(request.IdProductDelete);
                if (productDelete == null) return BaseResponse<int>.BadRequest("El producto no existe");

                productDelete.Observation = "Producto eliminado";
                productDelete.CreatedAt = DateTime.Now;
                productDelete.Isactive = false;


                _productRepository.Update(productDelete);
                var result = await _productRepository.SaveChangesAsync();
                if (result == 0) return BaseResponse<int>.BadRequest("Producto no se puede eliminar");
                return BaseResponse<int>.Ok(result, "Eliminación exitosa");
            }
            catch (Exception ex)
            {
                return BaseResponse<int>.BadRequest(ex.Message);
            }
        }
    }
}
