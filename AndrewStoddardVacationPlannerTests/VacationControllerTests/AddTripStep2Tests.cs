using System;
using AndrewStoddardVacationPlanner.Controllers;
using AndrewStoddardVacationPlanner.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace AndrewStoddardVacationPlannerTests.VacationControllerTests
{
    public class AddTripStep2Tests
    {
        #region Methods

        [Fact]
        public void AddTripStep2_ModelStateValid_ReturnsViewResult()
        {
            var httpContextAccessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var tempData = new TempDataDictionary(httpContextAccessor.Object.HttpContext, Mock.Of<ITempDataProvider>());
            var controller = new VacationController(unitOfWork.Object, httpContextAccessor.Object);
            controller.TempData = tempData;
            var trip = new Trip {
                Id = 1,
                DestinationId = 6,
                AccommodationId = 4,
                StartDate = new DateTime(2020, 12, 20),
                EndDate = new DateTime(2021, 1, 2)
            };
            var result = controller.AddTripStep2(trip) as ViewResult;
            Assert.IsType<ViewResult>(result);
            Assert.Equal(trip.DestinationId, controller.TempData["trip_dest"]);
            Assert.Equal(trip.AccommodationId, controller.TempData["trip_acc"]);
            Assert.Equal(trip.StartDate, controller.TempData["trip_start"]);
            Assert.Equal(trip.EndDate, controller.TempData["trip_end"]);
        }

        [Fact]
        public void AddTripStep2_ModelStateInValid_ReturnsViewResult()
        {
            var httpContextAccessor = TestHelperLibrary.SetUpHttpContextAccessor();
            var unitOfWork = TestHelperLibrary.SetupUnitOfWork();
            var controller = new VacationController(unitOfWork.Object, httpContextAccessor.Object);
            controller.ModelState.AddModelError("error", "error");
            var trip = new Trip {
                Id = 1,
                DestinationId = 6,
                AccommodationId = 4,
                StartDate = new DateTime(2020, 12, 20),
                EndDate = new DateTime(2021, 1, 2)
            };
            var result = controller.AddTripStep2(trip) as ViewResult;
            Assert.IsType<ViewResult>(result);
        }

        #endregion
    }
}