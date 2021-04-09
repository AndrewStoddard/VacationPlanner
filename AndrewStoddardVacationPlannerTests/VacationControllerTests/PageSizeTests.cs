using AndrewStoddardVacationPlanner.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AndrewStoddardVacationPlannerTests.VacationControllerTests
{
    public class PageSizeTests
    {
        #region Methods

        [Fact]
        public void PageSize_ReturnsRedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();

            var controller = new VacationController(unitOfWork.Object, accessor.Object);

            var result = controller.PageSize(1) as RedirectToActionResult;

            Assert.IsType<RedirectToActionResult>(result);
        }

        #endregion
    }
}