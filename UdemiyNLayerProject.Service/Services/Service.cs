using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Repostories;
using UdemiyNLayerProject.Core.Services;
using UdemiyNLayerProject.Core.UnitOfWorks;

namespace UdemiyNLayerProject.Service.Services
{
    class Service<TEtity> : IService<TEtity> where TEtity : class
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepostory<TEtity> _repostory;

        public Service(IUnitOfWork unitOfWork, IRepostory<TEtity> repostory)
        {
            _unitOfWork = unitOfWork;
            _repostory = repostory;
        }

        public async Task<TEtity> AddAsync(TEtity entity)
        {
            await _repostory.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<TEtity>> AddRangeAsync(IEnumerable<TEtity> entities)
        {
            await _repostory.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<IEnumerable<TEtity>> GetAllAsync()
        {
            return await _repostory.GetAllAsync();
        }

        public async Task<TEtity> GetByIdAsync(int id)
        {
            return await _repostory.GetByIdAsync(id);
        }

        public void Remove(TEtity entity)
        {
            _repostory.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEtity> entities)
        {
            _repostory.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public  async Task<TEtity> SingleOrDefaultAsync(Expression<Func<TEtity, bool>> predicate)
        {
            return await _repostory.SingleOrDefaultAsync(predicate);


        }

        public TEtity Update(TEtity entity)
        {
            var UpdateEntity = _repostory.Update(entity);
            _unitOfWork.Commit();
            return UpdateEntity;
        }

        public Task<IEnumerable<TEtity>> Where(Expression<Func<TEtity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
