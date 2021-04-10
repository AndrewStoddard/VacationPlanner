// ***********************************************************************
// Author           : Incendy
// Created          : 04-08-2021
//
// Last Modified By : Incendy
// Last Modified On : 04-08-2021
// ***********************************************************************

using AndrewStoddardVacationPlanner.Models.Configuration;
using AndrewStoddardVacationPlanner.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace AndrewStoddardVacationPlanner.Models.DataAccessLayer
{
    /// <summary>
    ///     Class VacationContext.
    ///     Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class VacationContext : DbContext
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the accommodations.
        /// </summary>
        /// <value>The accommodations.</value>
        public DbSet<Accommodation> Accommodations { get; set; }

        /// <summary>
        ///     Gets or sets the activities.
        /// </summary>
        /// <value>The activities.</value>
        public DbSet<Activity> Activities { get; set; }

        /// <summary>
        ///     Gets or sets the destinations.
        /// </summary>
        /// <value>The destinations.</value>
        public DbSet<Destination> Destinations { get; set; }

        /// <summary>
        ///     Gets or sets the trips.
        /// </summary>
        /// <value>The trips.</value>
        public DbSet<Trip> Trips { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="VacationContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public VacationContext(DbContextOptions<VacationContext> options) : base(options)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccommodationConfig());
            modelBuilder.ApplyConfiguration(new DestinationConfig());
            modelBuilder.ApplyConfiguration(new ActivityConfig());
            modelBuilder.ApplyConfiguration(new TripConfig());
        }

        #endregion
    }
}