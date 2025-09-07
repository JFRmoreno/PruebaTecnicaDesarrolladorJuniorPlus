using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Aplication.DTOs;
using PruebaTecnica.Aplication.Services.Interface.Services;

namespace PruebaTecnica.Api.Controllers
{
    [ApiController]
    [Route("api/products/delete")]
    public class DeleteController : Controller
    {

        private readonly IDeleteProductsServices _services;

        public DeleteController(IDeleteProductsServices services)
        {
            _services = services;
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteProductsRequest request)
        {
            var result = await _services.Delete(request);
            return Ok(result);
        }
    }
}
