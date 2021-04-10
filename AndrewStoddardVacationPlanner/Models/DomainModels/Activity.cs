// ***********************************************************************
// Author           : Incendy
// Created          : 04-08-2021
//
// Last Modified By : Incendy
// Last Modified On : 04-08-2021
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AndrewStoddardVacationPlanner.Models.DomainModels
{
    /// <summary>
    ///     Class Activity.
    /// </summary>
    public class Activity
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required(ErrorMessage = "Activity Name is required")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the trips.
        /// </summary>
        /// <value>The trips.</value>
        [Required]
        public virtual ICollection<Trip> Trips { get; set; }

        #endregion
    }
}