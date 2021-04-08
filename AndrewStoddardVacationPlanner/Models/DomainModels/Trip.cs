using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AndrewStoddardVacationPlanner.Models.DomainModels
{
    public class Trip
    {
        #region Properties

        public int Id { get; set; }

        [Required] public int DestinationId { get; set; }

        public Destination Destination { get; set; }

        [Required] public int AccommodationId { get; set; }

        public Accommodation Accommodation { get; set; }

        [Required] public virtual ICollection<Activity> Activities { get; set; }

        [Required] [DataType(DataType.Date)] public DateTime StartDate { get; set; }

        [Required] [DataType(DataType.Date)] public DateTime EndDate { get; set; }

        #endregion
    }
}