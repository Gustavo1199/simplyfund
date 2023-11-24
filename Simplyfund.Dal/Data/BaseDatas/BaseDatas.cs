using Microsoft.EntityFrameworkCore;
using Simplyfund.Dal.Data.IBaseDatas;
using Simplyfund.Dal.DataBase;
using SimplyFund.Domain.Base.Filter;
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

        private readonly SimplyfundDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseDatas(SimplyfundDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            _dbSet = _context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            try
            {
                if (_dbSet != null)
                {
                    return _dbSet.Find(id);
                }
                else
                {
                    throw new InvalidOperationException("");
                }
               


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

        public PaginatedList<T> FilterAndPaginate(FilterAndPaginateRequestModel? filters)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filters != null)
            {
                if (filters.IncludeProperties != null)
                {
                    foreach (var includeProperty in filters.IncludeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }

                if (filters.Filters != null)
                {
                    foreach (var filter in filters.Filters)
                    {
                        query = query.Where(e => EF.Property<object>(e, filter.PropertyName) == filter.Value);
                    }
                }

                if (!string.IsNullOrEmpty(filters.OrderProperty))
                {
                    try
                    {
                        var propertyInfo = typeof(T).GetProperty(filters.OrderProperty);
                        if (propertyInfo == null)
                        {
                            throw new ArgumentException($"La propiedad de ordenación '{filters.OrderProperty}' no existe en el modelo.");
                        }

                        query = filters.OrderDirection == "desc"
                            ? query.OrderByDescending(e => EF.Property<object>(e, filters.OrderProperty))
                            : query.OrderBy(e => EF.Property<object>(e, filters.OrderProperty));
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException($"Error al ordenar por la propiedad '{filters.OrderProperty}'. Detalles: {ex.Message}");
                    }
                }

                int count = query.Count();

                query = query.Skip((filters.PageIndex - 1) * filters.PageSize).Take(filters.PageSize);

                List<T> result = query.ToList();

                return new PaginatedList<T>(result, count, filters.PageIndex, filters.PageSize);
            }
            else
            {
                return new PaginatedList<T>(new List<T>(), 2, 1, 3);
            }
        }


        public async Task<PaginatedList<T>> FilterAndPaginateAsync(FilterAndPaginateRequestModel? filters)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filters != null)
            {
                if (filters.IncludeProperties != null)
                {
                    foreach (var includeProperty in filters.IncludeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }

                if (filters.Filters != null)
                {
                    foreach (var filter in filters.Filters)
                    {
                        query = query.Where(e => EF.Property<object>(e, filter.PropertyName) == filter.Value);
                    }
                }

                if (!string.IsNullOrEmpty(filters.OrderProperty))
                {
                    try
                    {
                        var propertyInfo = typeof(T).GetProperty(filters.OrderProperty);
                        if (propertyInfo == null)
                        {
                            throw new ArgumentException($"La propiedad de ordenación '{filters.OrderProperty}' no existe en el modelo.");
                        }

                        query = filters.OrderDirection == "desc"
                            ? query.OrderByDescending(e => EF.Property<object>(e, filters.OrderProperty))
                            : query.OrderBy(e => EF.Property<object>(e, filters.OrderProperty));
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException($"Error al ordenar por la propiedad '{filters.OrderProperty}'. Detalles: {ex.Message}");
                    }
                }

                int count = await query.CountAsync();

                query = query.Skip((filters.PageIndex - 1) * filters.PageSize).Take(filters.PageSize);

                List<T> result = await query.ToListAsync();

                return new PaginatedList<T>(result, count, filters.PageIndex, filters.PageSize);
            }
            else
            {
                return new PaginatedList<T>(new List<T>(), 2, 1, 3);
            }
        }

    }
}

