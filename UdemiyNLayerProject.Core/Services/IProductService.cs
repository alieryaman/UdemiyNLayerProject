using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Models;

namespace UdemiyNLayerProject.Core.Services
{
    interface IProductService:IService<Product>
    {
        // bool ControlInnerBarcode(Product product);
        Task<Product> GetWithCategoryByIdAsync(int productId);

    }
}
