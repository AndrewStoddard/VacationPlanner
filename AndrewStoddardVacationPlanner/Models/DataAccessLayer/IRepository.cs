﻿// ***********************************************************************
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
    ///     Interface IRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        #region Methods

        /// <summary>
        ///     Gets the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        IQueryable<T> Get(Expression<Func<T, bool>> expression = null);

        /// <summary>
        ///     Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(T entity);

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        #endregion
    }
}