using AndrewStoddardVacationPlanner.Models.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace AndrewStoddardVacationPlanner.Controllers
{
    public class VacationController : Controller
    {
        #region Data members

        private IUnitOfWork unitOfWork;

        #endregion

        #region Constructors

        public VacationController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public IActionResult Home()
        {
            return View();
        }

        #endregion
    }
}