using AndrewStoddardVacationPlanner.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace AndrewStoddardVacationPlanner.Models.DataAccessLayer
{
    public class VacationContext : DbContext
    {
        #region Properties

        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Trip> Trips { get; set; }

        #endregion

        #region Constructors

        public VacationContext(DbContextOptions<VacationContext> options) : base(options)
        {
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        #endregion
    }
}