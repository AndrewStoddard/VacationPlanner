// ***********************************************************************
// Author           : Incendy
// Created          : 04-08-2021
//
// Last Modified By : Incendy
// Last Modified On : 04-08-2021
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AndrewStoddardVacationPlanner.Models.DomainModels
{
    /// <summary>
    ///     Class Trip.
    /// </summary>
    public class Trip
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the destination identifier.
        /// </summary>
        /// <value>The destination identifier.</value>
        [Required]
        public int DestinationId { get; set; }

        /// <summary>
        ///     Gets or sets the destination.
        /// </summary>
        /// <value>The destination.</value>
        public Destination Destination { get; set; }

        /// <summary>
        ///     Gets or sets the accommodation identifier.
        /// </summary>
        /// <value>The accommodation identifier.</value>
        [Required]
        public int AccommodationId { get; set; }

        /// <summary>
        ///     Gets or sets the accommodation.
        /// </summary>
        /// <value>The accommodation.</value>
        public Accommodation Accommodation { get; set; }

        /// <summary>
        ///     Gets or sets the activities.
        /// </summary>
        /// <value>The activities.</value>
        public virtual ICollection<Activity> Activities { get; set; }

        /// <summary>
        ///     Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        #endregion
    }
}