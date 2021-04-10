// ***********************************************************************
// Author           : Incendy
// Created          : 04-08-2021
//
// Last Modified By : Incendy
// Last Modified On : 04-08-2021
// ***********************************************************************

using System;
using System.Linq;
using System.Linq.Expressions;

namespace AndrewStoddardVacationPlanner.Models.DataAccessLayer
{
    /// <summary>
    ///     Class Repository.
    ///     Implements the <see cref="AndrewStoddardVacationPlanner.Models.DataAccessLayer.IRepository{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="AndrewStoddardVacationPlanner.Models.DataAccessLayer.IRepository{T}" />
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Data members

        /// <summary>
        ///     The context
        /// </summary>
        protected VacationContext context;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Repository{T}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(VacationContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? this.context.Set<T>() : this.context.Set<T>().Where(expression);
        }

        /// <summary>
        ///     Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        #endregion
    }
}