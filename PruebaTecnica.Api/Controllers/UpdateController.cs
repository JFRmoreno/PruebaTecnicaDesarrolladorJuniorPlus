using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Aplication.DTOs;
using PruebaTecnica.Aplication.Services.Interface.Services;

namespace PruebaTecnica.Api.Controllers
{
    [ApiController]
    [Route("api/products/update")]
    public class UpdateController : Controller
    {

        private readonly IUpdateProductsServices _services;

        public UpdateController(IUpdateProductsServices services)
        {
            _services = services;
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateProductRequest request)
        {
            var result = await _services.Update(request);
            return Ok(result);
        }
    }
}
