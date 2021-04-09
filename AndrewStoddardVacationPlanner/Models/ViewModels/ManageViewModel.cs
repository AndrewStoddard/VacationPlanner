using System.Collections.Generic;
using AndrewStoddardVacationPlanner.Models.DomainModels;

namespace AndrewStoddardVacationPlanner.Models.ViewModels
{
    public class ManageViewModel
    {
        #region Properties

        public string AccommodationName { get; set; }
        public string AccommodationEmail { get; set; }
        public string AccommodationPhone { get; set; }
        public string ActivityName { get; set; }
        public string DestinationName { get; set; }

        public List<Destination> Destinations { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Accommodation> Accommodations { get; set; }

        public int SelectedActivityToDelete { get; set; }
        public int SelectedAccommodationToDelete { get; set; }
        public int SelectedDestinationToDelete { get; set; }

        #endregion
    }
}