using System;
using System.Linq;
using System.Linq.Expressions;

namespace AndrewStoddardVacationPlanner.Models.DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
        #region Methods

        IQueryable<T> Get(Expression<Func<T, bool>> expression = null);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        #endregion
    }
}