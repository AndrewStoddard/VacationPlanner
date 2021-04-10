using System;
using AndrewStoddardVacationPlanner.Controllers;
using AndrewStoddardVacationPlanner.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace AndrewStoddardVacationPlannerTests.VacationControllerTests
{
    public class AddTripTests
    {
        #region Methods

        [Fact]
        public void AddTrip_ReturnsRedirectToAction()
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
            controller.TempData["trip_dest"] = trip.DestinationId;
            controller.TempData["trip_acc"] = trip.AccommodationId;
            controller.TempData["trip_start"] = trip.StartDate;
            controller.TempData["trip_end"] = trip.EndDate;
            var result = controller.AddTrip(new[] {1, 2}) as RedirectToActionResult;
            Assert.IsType<RedirectToActionResult>(result);
        }

        #endregion
    }
}