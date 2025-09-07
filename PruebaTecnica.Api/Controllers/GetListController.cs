using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Aplication.Services.Interface.Services;

namespace PruebaTecnica.Api.Controllers
{
    [ApiController]
    [Route("api/products(ListarConPaginación)")]
    public class GetListController : Controller
    {

        private readonly IGetListProductServices _services;

        public GetListController(IGetListProductServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> Gelist([FromQuery] int pageZise, int row)
        {
            var result = await _services.GetAllProducts(pageZise, row);
            return Ok(result);
        }
    }
}
