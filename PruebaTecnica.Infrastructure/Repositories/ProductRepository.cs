using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Aplication.DTOs;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces.Repositories;
using PruebaTecnica.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class ProductRepository(AplicationDbContext context) : BaseRepository<Product>(context), IProductRepository
    {
        public async Task<List<Product>> GetListProduct()
        {
            return await _context.Products.Where(x=> x.Isactive == true).ToListAsync();
        }

        public async Task<Product?> GetToProduct(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(x=> x.Name == name);
        }

        public async Task<Product?> UpdateProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
