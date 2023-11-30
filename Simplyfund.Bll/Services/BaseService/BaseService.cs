using Simplyfund.Bll.ServicesInterface.IBaseServices;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Base.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.Services.BaseServices
{
    public class BaseService<T> : IBaseServices<T> where T : class
    {
         IBaseDatas<T> baseModel;
        public BaseService(IBaseDatas<T> baseModel)
        {
            this.baseModel = baseModel;
        }
        public virtual void Add(T entity)
        {
            try
            {
                baseModel.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
              await  baseModel.AddAsync(entity);
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
         
                return baseModel.AddAndReturn(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task<T> AddAndReturnAsync(T entity)
        {
            try
            {
                return await baseModel.AddAndReturnAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual void AddMany(IEnumerable<T> entities)
        {
            try
            {
                baseModel.AddMany(entities);
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
                return baseModel.Count(predicate);
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
              return  baseModel.Delete(entity);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return baseModel.Get(predicate);
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
                return baseModel.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            try
            {
                return await baseModel.GetAsync();
            }
            catch (Exception)
            {

                throw;
            }      
        
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await baseModel.GetAsync(predicate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  virtual T GetById(int id)
        {
            try
            {
                return baseModel.GetById(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual T GetIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                return baseModel.GetIncluding(predicate, includes);
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
                return baseModel.GetMany(predicate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await baseModel.GetManyAsync(predicate);
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
                 baseModel.Update(entity);
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
                return baseModel.UpdateAndReturn(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  virtual async Task<T> UpdateAndReturnAsync(T entity)
        {
            try
            {
                return await baseModel.UpdateAndReturnAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PaginatedList<T> FilterAndPaginate(FilterAndPaginateRequestModel? filters)
        {
            try
            {
                return baseModel.FilterAndPaginate(filters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PaginatedList<T>> FilterAndPaginateAsync(FilterAndPaginateRequestModel? filters)
        {
            try
            {
                return await baseModel.FilterAndPaginateAsync(filters);
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}
