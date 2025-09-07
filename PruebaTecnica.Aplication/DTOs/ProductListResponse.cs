using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Aplication.DTOs
{
    public class ProductListResponse
    {
        public List<ProductResponse> Products { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
