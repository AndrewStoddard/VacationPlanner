using AndrewStoddardVacationPlanner.Controllers;
using AndrewStoddardVacationPlanner.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace AndrewStoddardVacationPlannerTests.VacationControllerTests
{
    public class ManageTests
    {
        #region Methods

        [Fact]
        public void Manage_ReturnsViewWithNullValues()
        {
            var httpContextAccessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(httpContextAccessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, httpContextAccessor.Object);
            controller.TempData = tempData;
            var result = controller.Manage() as ViewResult;
            Assert.IsType<ViewResult>(result);
            var model = result.Model as ManageViewModel;
            Assert.Equal("", model.AccommodationPhone);
            Assert.Equal("", model.AccommodationEmail);
            Assert.Equal("", model.AccommodationName);
            Assert.Equal("", model.ActivityName);
            Assert.Equal("", model.DestinationName);
        }

        [Fact]
        public void Manage_ReturnsViewWithNonNullValues()
        {
            var httpContextAccessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(httpContextAccessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, httpContextAccessor.Object);
            tempData["dest_name"] = "Test1";
            tempData["acc_name"] = "Test2";
            tempData["acc_email"] = "Test3";
            tempData["acc_phone"] = "Test4";
            tempData["act_name"] = "Test5";
            controller.TempData = tempData;
            var result = controller.Manage() as ViewResult;
            Assert.IsType<ViewResult>(result);
            var model = result.Model as ManageViewModel;
            Assert.Equal("Test4", model.AccommodationPhone);
            Assert.Equal("Test3", model.AccommodationEmail);
            Assert.Equal("Test2", model.AccommodationName);
            Assert.Equal("Test5", model.ActivityName);
            Assert.Equal("Test1", model.DestinationName);
        }

        #endregion
    }
}