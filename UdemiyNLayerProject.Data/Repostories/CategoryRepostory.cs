using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Models;
using UdemiyNLayerProject.Core.Repostories;

namespace UdemiyNLayerProject.Data.Repostories
{
    class CategoryRepostory : Repostory<Category>, ICategoryRepostory
    {

        private AppDbContext _appDbContext { get => _context as AppDbContext; }


        public CategoryRepostory(DbContext context) : base(context)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int CategoryId)
        {
            return await _appDbContext.Categories.Include(x=>x.Products).SingleOrDefaultAsync(x=>x.Id==CategoryId);
        }
    }
}
