using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Models;
using UdemiyNLayerProject.Core.Repostories;
using UdemiyNLayerProject.Core.Services;
using UdemiyNLayerProject.Core.UnitOfWorks;

namespace UdemiyNLayerProject.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepostory<Category> repostory) : base(unitOfWork, repostory)
        {
        }

        public async Task<Category> GetWithProductByIdAsync(int categoryId)
        {
          return await  _unitOfWork.categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
