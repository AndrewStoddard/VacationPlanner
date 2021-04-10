using AndrewStoddardVacationPlanner.Controllers;
using AndrewStoddardVacationPlanner.Models.Enums;
using AndrewStoddardVacationPlanner.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AndrewStoddardVacationPlannerTests.VacationControllerTests
{
    public class HomeTests
    {
        #region Methods

        [Fact]
        public void SortIsAscending_ByDestination_ReturnsHomeView()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            accessor.Object.HttpContext.Session.SetInt32("page_size", 3);

            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.Sort(SortType.SortByDestination);

            var result = controller.Home() as ViewResult;
            var viewModel = result.Model as VacationListViewModel;
            Assert.Equal(2, viewModel.Trips[0].Id);
            Assert.Equal(3, viewModel.Trips[1].Id);
            Assert.Equal(1, viewModel.Trips[2].Id);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void SortIsDescending_ByDestination_ReturnsHomeView()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            accessor.Object.HttpContext.Session.SetInt32("page_size", 3);

            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.Sort(SortType.SortByDestination);
            controller.Sort(SortType.SortByDestination);

            var result = controller.Home() as ViewResult;
            var viewModel = result.Model as VacationListViewModel;
            Assert.Equal(2, viewModel.Trips[2].Id);
            Assert.Equal(3, viewModel.Trips[1].Id);
            Assert.Equal(1, viewModel.Trips[0].Id);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void SortIsAscending_ByStartDate_ReturnsHomeView()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            accessor.Object.HttpContext.Session.SetInt32("page_size", 3);

            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.Sort(SortType.SortByStartDate);

            var result = controller.Home() as ViewResult;
            var viewModel = result.Model as VacationListViewModel;
            Assert.Equal(3, viewModel.Trips[0].Id);
            Assert.Equal(2, viewModel.Trips[1].Id);
            Assert.Equal(1, viewModel.Trips[2].Id);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void SortIsDescending_ByStartDate_ReturnsHomeView()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            accessor.Object.HttpContext.Session.SetInt32("page_size", 3);

            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.Sort(SortType.SortByStartDate);
            controller.Sort(SortType.SortByStartDate);

            var result = controller.Home() as ViewResult;
            var viewModel = result.Model as VacationListViewModel;
            Assert.Equal(3, viewModel.Trips[2].Id);
            Assert.Equal(2, viewModel.Trips[1].Id);
            Assert.Equal(1, viewModel.Trips[0].Id);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void SortIsAscending_ByEndDate_ReturnsHomeView()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            accessor.Object.HttpContext.Session.SetInt32("page_size", 3);

            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.Sort(SortType.SortByEndDate);

            var result = controller.Home() as ViewResult;
            var viewModel = result.Model as VacationListViewModel;
            Assert.Equal(3, viewModel.Trips[0].Id);
            Assert.Equal(1, viewModel.Trips[2].Id);
            Assert.Equal(2, viewModel.Trips[1].Id);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void SortIsDescending_ByEndDate_ReturnsHomeView()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();

            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.Sort(SortType.SortByEndDate);
            controller.Sort(SortType.SortByEndDate);
            accessor.Object.HttpContext.Session.SetInt32("page_size", 3);

            var result = controller.Home() as ViewResult;
            var viewModel = result.Model as VacationListViewModel;
            Assert.Equal(3, viewModel.Trips[2].Id);
            Assert.Equal(1, viewModel.Trips[0].Id);
            Assert.Equal(2, viewModel.Trips[1].Id);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void SortIsAscending_ByAcc_ReturnsHomeView()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            accessor.Object.HttpContext.Session.SetInt32("page_size", 3);

            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.Sort(SortType.SortByAccommodation);

            var result = controller.Home() as ViewResult;
            var viewModel = result.Model as VacationListViewModel;
            Assert.Equal(1, viewModel.Trips[0].Id);
            Assert.Equal(2, viewModel.Trips[1].Id);
            Assert.Equal(3, viewModel.Trips[2].Id);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void SortIsDescending_ByAcc_ReturnsHomeView()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            accessor.Object.HttpContext.Session.SetInt32("page_size", 3);

            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.Sort(SortType.SortByAccommodation);
            controller.Sort(SortType.SortByAccommodation);

            var result = controller.Home() as ViewResult;
            var viewModel = result.Model as VacationListViewModel;
            Assert.Equal(1, viewModel.Trips[2].Id);
            Assert.Equal(3, viewModel.Trips[1].Id);
            Assert.Equal(2, viewModel.Trips[0].Id);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void SortIsAscending_ByAct_ReturnsHomeView()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            accessor.Object.HttpContext.Session.SetInt32("page_size", 3);

            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.Sort(SortType.SortByActivities);

            var result = controller.Home() as ViewResult;
            var viewModel = result.Model as VacationListViewModel;
            Assert.Equal(1, viewModel.Trips[0].Id);
            Assert.Equal(2, viewModel.Trips[1].Id);
            Assert.Equal(3, viewModel.Trips[2].Id);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void SortIsDescending_ByAct_ReturnsHomeView()
        {
            var accessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            accessor.Object.HttpContext.Session.SetInt32("page_size", 3);
            var controller = new VacationController(unitOfWork.Object, accessor.Object);
            controller.Sort(SortType.SortByActivities);
            controller.Sort(SortType.SortByActivities);

            var result = controller.Home() as ViewResult;
            var viewModel = result.Model as VacationListViewModel;
            Assert.Equal(3, viewModel.Trips[2].Id);
            Assert.Equal(2, viewModel.Trips[1].Id);
            Assert.Equal(1, viewModel.Trips[0].Id);
            Assert.IsType<ViewResult>(result);
        }

        #endregion
    }
}