using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Models;

namespace UdemiyNLayerProject.Core.Services
{
    public interface ICategoryService:IService<Category>
    {

        Task<Category> GetWithProductByIdAsync(int categoryId);
    }
}
