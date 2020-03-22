using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Models;
using UdemiyNLayerProject.Core.Repostories;

namespace UdemiyNLayerProject.Data.Repostories
{
   public class ProductRepostory : Repostory<Product>, IProductRepostory
    {
        private AppDbContext _appDbContext   { get => _context as AppDbContext; }


        public ProductRepostory(DbContext context):base (context)
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id==productId);
        }
    }
}
