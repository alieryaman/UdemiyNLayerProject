using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Models;
using UdemiyNLayerProject.Core.Repostories;
using UdemiyNLayerProject.Core.Services;
using UdemiyNLayerProject.Core.UnitOfWorks;

namespace UdemiyNLayerProject.Service.Services
{
   public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepostory<Product> repostory) : base(unitOfWork, repostory)
        {
        }

        public  async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
