using System.Collections.Generic;
using AndrewStoddardVacationPlanner.Models.DomainModels;

namespace AndrewStoddardVacationPlanner.Models.ViewModels
{
    public class VacationListViewModel
    {
        #region Properties

        public List<Trip> Trips { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int[] PageSizes { get; } = {1, 2, 3, 4, 5};

        #endregion
    }
}