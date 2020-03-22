using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Services;

namespace UdemiyNLayerProject.Service.Services
{
    class Service<TEtity> : IService<TEtity> where TEtity : class
    {


        public Task<TEtity> AddAsync(TEtity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEtity>> AddRangeAsync(IEnumerable<TEtity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEtity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEtity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEtity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEtity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<TEtity> SingleOrDefaultAsync(Expression<Func<TEtity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEtity Update(TEtity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEtity>> Where(Expression<Func<TEtity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
