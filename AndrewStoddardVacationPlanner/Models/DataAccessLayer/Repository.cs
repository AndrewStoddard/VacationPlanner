using System;
using System.Linq;
using System.Linq.Expressions;

namespace AndrewStoddardVacationPlanner.Models.DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Data members

        protected VacationContext context;

        #endregion

        #region Constructors

        public Repository(VacationContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? this.context.Set<T>() : this.context.Set<T>().Where(expression);
        }

        public virtual void Insert(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        #endregion
    }
}