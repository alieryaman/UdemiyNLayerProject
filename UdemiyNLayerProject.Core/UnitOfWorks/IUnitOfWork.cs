using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Repostories;

namespace UdemiyNLayerProject.Core.UnitOfWorks
{
   public interface IUnitOfWork
    {
        IProductRepostory Products { get; }
        ICategoryRepostory categories { get; }
        Task CommitAsync();
        void Commit();

    }
}
