// ***********************************************************************
// Author           : Incendy
// Created          : 04-08-2021
//
// Last Modified By : Incendy
// Last Modified On : 04-08-2021
// ***********************************************************************

using AndrewStoddardVacationPlanner.Models.DomainModels;

namespace AndrewStoddardVacationPlanner.Models.DataAccessLayer
{
    /// <summary>
    ///     Interface IUnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        #region Properties

        /// <summary>
        ///     Gets the accommodations.
        /// </summary>
        /// <value>The accommodations.</value>
        IRepository<Accommodation> Accommodations { get; }

        /// <summary>
        ///     Gets the activities.
        /// </summary>
        /// <value>The activities.</value>
        IRepository<Activity> Activities { get; }

        /// <summary>
        ///     Gets the destinations.
        /// </summary>
        /// <value>The destinations.</value>
        IRepository<Destination> Destinations { get; }

        /// <summary>
        ///     Gets the trips.
        /// </summary>
        /// <value>The trips.</value>
        IRepository<Trip> Trips { get; }

        #endregion

        #region Methods

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        void Save();

        #endregion
    }
}