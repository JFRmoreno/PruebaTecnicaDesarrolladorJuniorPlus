using PruebaTecnica.Aplication.DTOs;
using PruebaTecnica.Aplication.Services.Interface.Services;
using PruebaTecnica.Domain.Interfaces.Repositories;
using Domain.Common.Response;

namespace PruebaTecnica.Aplication.Services
{
    public class GetListProductServices :IGetListProductServices
    {

        private readonly IProductRepository _productRepository;

        public GetListProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<BaseResponse<ProductListResponse>> GetAllProducts(int pageZise, int row)
        {
            try
            {
                var productList = await _productRepository.GetListProduct();
                var totalCount = productList.Count;
                var page = productList
                    .Skip(row)
                    .Take(pageZise)
                    .Select(p => new ProductResponse
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        CreatedAt = p.CreatedAt
                    })
                    .ToList();
                var listProducts = new ProductListResponse
                {
                    TotalCount = totalCount,
                    Products = page
                };

                return BaseResponse<ProductListResponse>.Ok(listProducts, "Consulta completada");
            }

            catch (Exception ex) 
            {
                return BaseResponse<ProductListResponse>.BadRequest(ex.Message);
            }
        }

    }
}
