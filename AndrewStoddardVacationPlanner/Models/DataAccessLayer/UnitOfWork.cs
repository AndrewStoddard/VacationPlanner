using AndrewStoddardVacationPlanner.Models.DomainModels;

namespace AndrewStoddardVacationPlanner.Models.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Data members

        private readonly VacationContext context;

        #endregion

        #region Properties

        public IRepository<Accommodation> Accommodations { get; }
        public IRepository<Activity> Activities { get; }
        public IRepository<Destination> Destinations { get; }
        public IRepository<Trip> Trips { get; }

        #endregion

        #region Constructors

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

        public void Save()
        {
            this.context.SaveChanges();
        }

        #endregion
    }
}