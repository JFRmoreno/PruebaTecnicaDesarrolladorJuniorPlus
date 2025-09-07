using Domain.Common.Response;
using PruebaTecnica.Aplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Aplication.Services.Interface.Services
{
    public interface ICreateProductsServices
    {
        Task<BaseResponse<int>> Create(CreateProductsRequest request);
    }
}
