using AndrewStoddardVacationPlanner.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace AndrewStoddardVacationPlannerTests.VacationControllerTests
{
    public class DeleteTripTests
    {
        #region Methods

        [Fact]
        public void DeleteTrip_Delete1_ReturnsRedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;

            var result = controller.DeleteTrip(1) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
        }

        #endregion
    }
}