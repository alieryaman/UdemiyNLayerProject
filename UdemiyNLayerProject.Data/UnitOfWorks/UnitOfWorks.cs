using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Models;
using UdemiyNLayerProject.Core.Repostories;
using UdemiyNLayerProject.Core.UnitOfWorks;
using UdemiyNLayerProject.Data.Repostories;

namespace UdemiyNLayerProject.Data.UnitOfWorks
{
   public class UnitOfWorks : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductRepostory _productRepostory;
        private CategoryRepostory _CategoryRepostory;
        public IProductRepostory Products => _productRepostory=_productRepostory ?? new ProductRepostory(_context);

        public ICategoryRepostory categories =>  _CategoryRepostory = _CategoryRepostory ?? new CategoryRepostory(_context);

        public UnitOfWorks(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
