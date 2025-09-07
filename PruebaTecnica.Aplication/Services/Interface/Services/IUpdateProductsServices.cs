using Domain.Common.Response;
using PruebaTecnica.Aplication.DTOs;

namespace PruebaTecnica.Aplication.Services.Interface.Services
{
    public interface IUpdateProductsServices
    {
        Task<BaseResponse<int>> Update(UpdateProductRequest request);
    }
}
