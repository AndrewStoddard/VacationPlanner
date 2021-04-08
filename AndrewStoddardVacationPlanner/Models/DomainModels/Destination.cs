using System.ComponentModel.DataAnnotations;

namespace AndrewStoddardVacationPlanner.Models.DomainModels
{
    public class Destination
    {
        #region Properties

        public int Id { get; set; }

        [Required(ErrorMessage = "Destination name is Required")]
        public string Name { get; set; }

        #endregion
    }
}