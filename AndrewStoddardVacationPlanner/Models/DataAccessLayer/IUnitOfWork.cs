using AndrewStoddardVacationPlanner.Models.DomainModels;

namespace AndrewStoddardVacationPlanner.Models.DataAccessLayer
{
    public interface IUnitOfWork
    {
        #region Properties

        IRepository<Accommodation> Accommodations { get; }
        IRepository<Activity> Activities { get; }
        IRepository<Destination> Destinations { get; }
        IRepository<Trip> Trips { get; }

        #endregion

        #region Methods

        void Save();

        #endregion
    }
}