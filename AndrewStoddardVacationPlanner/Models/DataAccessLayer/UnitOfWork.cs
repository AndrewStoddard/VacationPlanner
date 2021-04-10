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
    ///     Class UnitOfWork.
    ///     Implements the <see cref="AndrewStoddardVacationPlanner.Models.DataAccessLayer.IUnitOfWork" />
    /// </summary>
    /// <seealso cref="AndrewStoddardVacationPlanner.Models.DataAccessLayer.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        #region Data members

        /// <summary>
        ///     The context
        /// </summary>
        private readonly VacationContext context;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the accommodations.
        /// </summary>
        /// <value>The accommodations.</value>
        public IRepository<Accommodation> Accommodations { get; }

        /// <summary>
        ///     Gets the activities.
        /// </summary>
        /// <value>The activities.</value>
        public IRepository<Activity> Activities { get; }

        /// <summary>
        ///     Gets the destinations.
        /// </summary>
        /// <value>The destinations.</value>
        public IRepository<Destination> Destinations { get; }

        /// <summary>
        ///     Gets the trips.
        /// </summary>
        /// <value>The trips.</value>
        public IRepository<Trip> Trips { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(VacationContext context)
        {
            this.context = context;
            this.Accommodations = new Repository<Accommodation>(context);
            this.Activities = new Repository<Activity>(context);
            this.Destinations = new Repository<Destination>(context);
            this.Trips = new Repository<Trip>(context);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
        }

        #endregion
    }
}