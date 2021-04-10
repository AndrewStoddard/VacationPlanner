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
    ///     Class ManageViewModel.
    /// </summary>
    public class ManageViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the name of the accommodation.
        /// </summary>
        /// <value>The name of the accommodation.</value>
        public string AccommodationName { get; set; }

        /// <summary>
        ///     Gets or sets the accommodation email.
        /// </summary>
        /// <value>The accommodation email.</value>
        public string AccommodationEmail { get; set; }

        /// <summary>
        ///     Gets or sets the accommodation phone.
        /// </summary>
        /// <value>The accommodation phone.</value>
        public string AccommodationPhone { get; set; }

        /// <summary>
        ///     Gets or sets the name of the activity.
        /// </summary>
        /// <value>The name of the activity.</value>
        public string ActivityName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the destination.
        /// </summary>
        /// <value>The name of the destination.</value>
        public string DestinationName { get; set; }

        /// <summary>
        ///     Gets or sets the destinations.
        /// </summary>
        /// <value>The destinations.</value>
        public List<Destination> Destinations { get; set; }

        /// <summary>
        ///     Gets or sets the activities.
        /// </summary>
        /// <value>The activities.</value>
        public List<Activity> Activities { get; set; }

        /// <summary>
        ///     Gets or sets the accommodations.
        /// </summary>
        /// <value>The accommodations.</value>
        public List<Accommodation> Accommodations { get; set; }

        /// <summary>
        ///     Gets or sets the selected activity to delete.
        /// </summary>
        /// <value>The selected activity to delete.</value>
        public int SelectedActivityToDelete { get; set; }

        /// <summary>
        ///     Gets or sets the selected accommodation to delete.
        /// </summary>
        /// <value>The selected accommodation to delete.</value>
        public int SelectedAccommodationToDelete { get; set; }

        /// <summary>
        ///     Gets or sets the selected destination to delete.
        /// </summary>
        /// <value>The selected destination to delete.</value>
        public int SelectedDestinationToDelete { get; set; }

        #endregion
    }
}