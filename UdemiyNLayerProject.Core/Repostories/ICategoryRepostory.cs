using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Models;

namespace UdemiyNLayerProject.Core.Repostories
{
    public interface ICategoryRepostory:IRepostory<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int CategoryId);


    }
}
