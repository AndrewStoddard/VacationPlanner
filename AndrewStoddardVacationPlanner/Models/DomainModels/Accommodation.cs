using System.ComponentModel.DataAnnotations;

namespace AndrewStoddardVacationPlanner.Models.DomainModels
{
    public class Accommodation
    {
        #region Properties

        public int Id { get; set; }

        [Required(ErrorMessage = "Accommodation name is required")]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        #endregion
    }
}