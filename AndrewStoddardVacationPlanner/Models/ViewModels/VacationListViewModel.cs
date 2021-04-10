// ***********************************************************************
// Author           : Incendy
// Created          : 04-08-2021
//
// Last Modified By : Incendy
// Last Modified On : 04-08-2021
// ***********************************************************************

using System.Collections.Generic;
using AndrewStoddardVacationPlanner.Models.DomainModels;

namespace AndrewStoddardVacationPlanner.Models.ViewModels
{
    /// <summary>
    ///     Class VacationListViewModel.
    /// </summary>
    public class VacationListViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the trips.
        /// </summary>
        /// <value>The trips.</value>
        public List<Trip> Trips { get; set; }

        /// <summary>
        ///     Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize { get; set; }

        /// <summary>
        ///     Gets or sets the page number.
        /// </summary>
        /// <value>The page number.</value>
        public int PageNumber { get; set; }

        /// <summary>
        ///     Gets or sets the total pages.
        /// </summary>
        /// <value>The total pages.</value>
        public int TotalPages { get; set; }

        /// <summary>
        ///     Gets the page sizes.
        /// </summary>
        /// <value>The page sizes.</value>
        public int[] PageSizes { get; } = {1, 2, 3, 4, 5};

        #endregion
    }
}