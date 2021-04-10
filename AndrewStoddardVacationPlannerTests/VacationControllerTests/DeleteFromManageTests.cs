using AndrewStoddardVacationPlanner.Controllers;
using AndrewStoddardVacationPlanner.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace AndrewStoddardVacationPlannerTests.VacationControllerTests
{
    public class DeleteFromManageTests
    {
        #region Methods

        [Fact]
        public void DeleteFromManage_SuccessfullyDeletesAcc_ReturnsRedirectToAction()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                SelectedAccommodationToDelete = 1,
                SelectedActivityToDelete = 0,
                SelectedDestinationToDelete = 0
            };
            var result = controller.DeleteFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", result.ActionName);
        }

        [Fact]
        public void DeleteFromManage_SuccessfullyDeletesAct_ReturnsRedirectToAction()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                SelectedAccommodationToDelete = 0,
                SelectedActivityToDelete = 1,
                SelectedDestinationToDelete = 0
            };
            var result = controller.DeleteFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", result.ActionName);
        }

        [Fact]
        public void DeleteFromManage_SuccessfullyDeletesDest_ReturnsRedirectToAction()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                SelectedAccommodationToDelete = 0,
                SelectedActivityToDelete = 0,
                SelectedDestinationToDelete = 1
            };
            var result = controller.DeleteFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", result.ActionName);
        }

        [Fact]
        public void DeleteFromManage_ContainsAcc_ContainsAct_ReturnsRedirectToAction()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                SelectedAccommodationToDelete = 1,
                SelectedActivityToDelete = 1,
                SelectedDestinationToDelete = 0
            };
            var result = controller.DeleteFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Manage", result.ActionName);
        }

        [Fact]
        public void DeleteFromManage_ContainsAcc_ContainsDest_ReturnsRedirectToAction()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                SelectedAccommodationToDelete = 1,
                SelectedActivityToDelete = 0,
                SelectedDestinationToDelete = 1
            };
            var result = controller.DeleteFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Manage", result.ActionName);
        }

        [Fact]
        public void DeleteFromManage_ContainsDest_ContainsAct_ReturnsRedirectToAction()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                SelectedAccommodationToDelete = 1,
                SelectedActivityToDelete = 0,
                SelectedDestinationToDelete = 1
            };
            var result = controller.DeleteFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Manage", result.ActionName);
        }

        [Fact]
        public void DeleteFromManage_ContainsNone_ReturnsRedirectToAction()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(accessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.TempData = tempData;
            var viewmodel = new ManageViewModel {
                SelectedAccommodationToDelete = 0,
                SelectedActivityToDelete = 0,
                SelectedDestinationToDelete = 0
            };
            var result = controller.DeleteFromManage(viewmodel) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Manage", result.ActionName);
        }

        #endregion
    }
}