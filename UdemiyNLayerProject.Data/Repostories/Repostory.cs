using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Repostories;

namespace UdemiyNLayerProject.Data.Repostories
{
  



   public class Repostory<TEntity> : IRepostory<TEntity> where TEntity : class
    {

        public readonly DbContext _context;
        public readonly DbSet<TEntity> _dbSet;
        public Repostory(AppDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRangeAsync(entities);
            
        }

         async Task<IEnumerable<TEntity>> IRepostory<TEntity>.Where(Expression<Func<TEntity, bool>> predicate)
        {
          return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

       

      

        void IRepostory<TEntity>.RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
           _context.Entry(entity).State = EntityState.Modified;
            //_dbSet.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {

            return await _dbSet.FindAsync(id);
            
        }
    }
}
