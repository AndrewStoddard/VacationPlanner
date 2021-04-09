using AndrewStoddardVacationPlanner.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AndrewStoddardVacationPlannerTests.VacationControllerTests
{
    public class AddTripStep1Tests
    {
        #region Methods

        [Fact]
        public void AddTripStep1_ReturnsViewResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var controller = new VacationController(unitOfWork.Object, accessor.Object);

            var result = controller.AddTripStep1() as ViewResult;
            Assert.IsType<ViewResult>(result);
        }

        #endregion
    }
}