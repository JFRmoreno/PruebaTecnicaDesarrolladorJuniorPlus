using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Aplication.DTOs;
using PruebaTecnica.Aplication.Services.Interface.Services;

namespace PruebaTecnica.Api.Controllers
{
    [ApiController]
    [Route("api/products(crear)")]
    public class CreateController : Controller
    {

        private readonly ICreateProductsServices _services;

        public CreateController(ICreateProductsServices services)
        {
            _services = services;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateProductsRequest request)
        {
            var result = await _services.Create(request);
            return Ok(result);
        }
    }
}
