using AndrewStoddardVacationPlanner.Controllers;
using AndrewStoddardVacationPlanner.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace AndrewStoddardVacationPlannerTests.VacationControllerTests
{
    public class AddFromManageTests
    {
        #region Methods

        [Fact]
        public void AddFromManage_SuccessfulAddAccommodation_WithAllFields_Returns_RedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                DestinationName = "",
                AccommodationName = "test",
                AccommodationEmail = "test@test",
                AccommodationPhone = "1234567890",
                ActivityName = ""
            };
            var result = controller.AddFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", result.ActionName);
        }

        [Fact]
        public void AddFromManage_AddAccommodation_WithBadPhone_Returns_RedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                DestinationName = "",
                AccommodationName = "test",
                AccommodationEmail = "test@test",
                AccommodationPhone = "123456789",
                ActivityName = ""
            };
            var result = controller.AddFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Manage", result.ActionName);
        }

        [Fact]
        public void AddFromManage_AddAccommodation_WithBadEmail_Returns_RedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                DestinationName = "",
                AccommodationName = "test",
                AccommodationEmail = "test",
                AccommodationPhone = "1234567890",
                ActivityName = ""
            };
            var result = controller.AddFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Manage", result.ActionName);
        }

        [Fact]
        public void AddFromManage_SuccessfulAddAccommodation_WithOnlyName_Returns_RedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                DestinationName = "",
                AccommodationName = "testacc",
                AccommodationEmail = "",
                AccommodationPhone = "",
                ActivityName = ""
            };
            var result = controller.AddFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", result.ActionName);
        }

        [Fact]
        public void AddFromManage_SuccessfulAddActivity_Returns_RedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                DestinationName = "",
                AccommodationName = "",
                AccommodationEmail = "",
                AccommodationPhone = "",
                ActivityName = "testact"
            };
            var result = controller.AddFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", result.ActionName);
        }

        [Fact]
        public void AddFromManage_SuccessfulAddDestination_Returns_RedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                DestinationName = "testdest",
                AccommodationName = "",
                AccommodationEmail = "",
                AccommodationPhone = "",
                ActivityName = ""
            };
            var result = controller.AddFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", result.ActionName);
        }

        [Fact]
        public void AddFromManage_ContainsAccOnlyName_ContainsAct_Returns_RedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                DestinationName = "",
                AccommodationName = "testacc",
                AccommodationEmail = "",
                AccommodationPhone = "",
                ActivityName = "testact"
            };
            var result = controller.AddFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Manage", result.ActionName);
        }

        [Fact]
        public void AddFromManage_ContainsAccASAll_ContainsAct_Returns_RedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                DestinationName = "",
                AccommodationName = "testacc",
                AccommodationEmail = "testacc@test",
                AccommodationPhone = "1234567890",
                ActivityName = "testact"
            };
            var result = controller.AddFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Manage", result.ActionName);
        }

        [Fact]
        public void AddFromManage_ContainsAccOnlyName_ContainsDest_Returns_RedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                DestinationName = "testdest",
                AccommodationName = "testacc",
                AccommodationEmail = "",
                AccommodationPhone = "",
                ActivityName = ""
            };
            var result = controller.AddFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Manage", result.ActionName);
        }

        [Fact]
        public void AddFromManage_ContainsAccAll_ContainsDest_Returns_RedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                DestinationName = "testdest",
                AccommodationName = "testacc",
                AccommodationEmail = "testacc@test",
                AccommodationPhone = "1234567890",
                ActivityName = ""
            };
            var result = controller.AddFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Manage", result.ActionName);
        }

        [Fact]
        public void AddFromManage_ContainsAct_ContainsDest_Returns_RedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                DestinationName = "testdest",
                AccommodationName = "",
                AccommodationEmail = "",
                AccommodationPhone = "",
                ActivityName = "testact"
            };
            var result = controller.AddFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Manage", result.ActionName);
        }

        [Fact]
        public void AddFromManage_ContainsNone_Returns_RedirectToActionResult()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                DestinationName = "",
                AccommodationName = "",
                AccommodationEmail = "",
                AccommodationPhone = "",
                ActivityName = ""
            };
            var result = controller.AddFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Manage", result.ActionName);
        }

        #endregion
    }
}