using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Models;

namespace UdemiyNLayerProject.Core.Repostories
{
    interface IProductRepostory
    {

        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
