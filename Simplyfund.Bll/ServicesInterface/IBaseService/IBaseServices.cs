﻿using SimplyFund.Domain.Base.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.ServicesInterface.IBaseServices
{
    public interface IBaseServices<T> where T : class 
    {
        T GetById(int id);

        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        Task AddAsync(T entity);

        void AddMany(IEnumerable<T> entities);
        void Update(T entity);

        Task<bool> UpdateAsync(T entity);
        bool Delete(T entity);

        Task<bool> DeleteByIdAsync(int id);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate);
        T GetIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        int Count(Expression<Func<T, bool>>? predicate = null);
        T AddAndReturn(T entity);
        T UpdateAndReturn(T entity);


        PaginatedList<T> FilterAndPaginate(FilterAndPaginateRequestModel? filters);
        Task<PaginatedList<T>> FilterAndPaginateAsync(FilterAndPaginateRequestModel? filters);

        #region async methop
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAndReturnAsync(T entity);
        Task<T> UpdateAndReturnAsync(T entity);
        #endregion
    }

}
