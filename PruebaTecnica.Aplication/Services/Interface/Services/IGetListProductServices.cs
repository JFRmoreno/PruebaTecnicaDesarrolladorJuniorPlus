using PruebaTecnica.Aplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Response;

namespace PruebaTecnica.Aplication.Services.Interface.Services
{
    public interface IGetListProductServices
    {
        Task<BaseResponse<ProductListResponse>> GetAllProducts(int pageZise, int row);
    }
}
