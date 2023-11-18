using Microsoft.EntityFrameworkCore;
using Simplyfund.Dal.DataBase;
using Simplyfund.Dal.DataBase.IBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Dal.Data.BaseData
{
    public  class BaseDatas<T> : IBaseDatas<T> where T : class
    {

        private readonly SimplyfundContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseDatas(SimplyfundContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception) { throw; }
        }

        public virtual void AddMany(IEnumerable<T> entities)
        {
            try
            {
                _dbSet.AddRange(entities);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                var tracked = _dbSet.Attach(entity);
                _context.Entry(tracked).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
               var de = _context.SaveChanges();
                return de > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _dbSet.Where(predicate).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual int Count(Expression<Func<T, bool>>? predicate = null)
        {
            try
            {
                return predicate == null ? _dbSet.Count() : _dbSet.Count(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual T AddAndReturn(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual T UpdateAndReturn(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public virtual T GetIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query.FirstOrDefault(predicate);
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _dbSet.Where(predicate).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> AddAndReturnAsync(T entity)
        {
            try
            {
                var add = _dbSet.Add(entity);
                await _context.SaveChangesAsync();


                return add.Entity;
            }
            catch (DbUpdateException)
            {

                throw;
            }

        }

        public virtual async Task<T> UpdateAndReturnAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

