﻿using System.ComponentModel.DataAnnotations;

namespace AndrewStoddardVacationPlanner.Models.DomainModels
{
    public class Activity
    {
        #region Properties

        public int Id { get; set; }

        [Required(ErrorMessage = "Activity Name is required")]
        public string Name { get; set; }

        #endregion
    }
}