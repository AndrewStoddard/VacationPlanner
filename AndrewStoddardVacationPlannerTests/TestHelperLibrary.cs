using System;
using System.Collections.Generic;
using System.Linq;
using AndrewStoddardVacationPlanner.Models.DataAccessLayer;
using AndrewStoddardVacationPlanner.Models.DomainModels;
using AndrewStoddardVacationPlannerTests.Fakes;
using Microsoft.AspNetCore.Http;
using Moq;

namespace AndrewStoddardVacationPlannerTests
{
    public class TestHelperLibrary
    {
        #region Methods

        public static Mock<IUnitOfWork> SetupUnitOfWork()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var acc1 = new Accommodation {
                Id = 1,
                Name = "High-Rise Condo",
                Email = "book@highrise.com",
                PhoneNumber = "1234567890"
            };
            var acc2 = new Accommodation {
                Id = 2,
                Name = "Low-Rise Condo",
                Email = "book@lowrise.com",
                PhoneNumber = "0987654321"
            };
            var acc3 = new Accommodation {
                Id = 3,
                Name = "Motel 8",
                Email = "book@motel8.com",
                PhoneNumber = "5632147890"
            };
            var acc4 = new Accommodation {
                Id = 4,
                Name = "Holiday Inn",
                Email = "book@holidayinn.com",
                PhoneNumber = "5823694170"
            };
            var accs = new List<Accommodation> {
                acc1, acc2, acc3, acc4
            };

            var act1 = new Activity {Id = 1, Name = "SkyDiving"};
            var act2 = new Activity {Id = 2, Name = "Parasail"};
            var act3 = new Activity {Id = 3, Name = "Go Karts"};
            var act4 = new Activity {Id = 4, Name = "Mini Golf"};
            var act5 = new Activity {Id = 5, Name = "Mountain Hiking"};
            var act6 = new Activity {Id = 6, Name = "Deep Sea Fishing"};

            var acts = new List<Activity> {
                act1, act2, act3, act4, act5, act6
            };

            var dest1 = new Destination {Id = 1, Name = "Orlando, Florida"};
            var dest2 = new Destination {Id = 2, Name = "Panama City, Florida"};
            var dest3 = new Destination {Id = 3, Name = "Orange Beach, Alabama"};
            var dest4 = new Destination {Id = 4, Name = "Helen, Georgia"};
            var dest5 = new Destination {Id = 5, Name = "New York City, New York"};
            var dest6 = new Destination {Id = 6, Name = "Gatlinburg, Tennessee"};

            var dests = new List<Destination> {
                dest1, dest2, dest3, dest4, dest5, dest6
            };

            var trip1 = new Trip {
                Id = 1,
                DestinationId = 6,
                Destination = dest6,
                AccommodationId = 4,
                Accommodation = acc4,
                StartDate = new DateTime(2019, 12, 20),
                EndDate = new DateTime(2020, 1, 2),
                Activities = new List<Activity> {act2, act4}
            };
            var trip2 = new Trip {
                Id = 2,
                DestinationId = 2,
                Destination = dest2,
                AccommodationId = 1,
                Accommodation = acc1,
                StartDate = new DateTime(2020, 5, 23),
                EndDate = new DateTime(2020, 6, 1),
                Activities = new List<Activity> {act1, act3}
            };

            var trip3 = new Trip {
                Id = 3,
                DestinationId = 4,
                Destination = dest4,
                AccommodationId = 1,
                Accommodation = acc1,
                StartDate = new DateTime(2020, 6, 23),
                EndDate = new DateTime(2020, 7, 1),
                Activities = new List<Activity> {act1, act3}
            };

            var trips = new List<Trip> {
                trip1, trip2, trip3
            };
            var accRepo = new Mock<IRepository<Accommodation>>();
            var actRepo = new Mock<IRepository<Activity>>();
            var destRepo = new Mock<IRepository<Destination>>();
            var tripRepo = new Mock<IRepository<Trip>>();

            accRepo.Setup(repo => repo.Get(null)).Returns(accs.AsQueryable());
            actRepo.Setup(repo => repo.Get(null)).Returns(acts.AsQueryable());
            destRepo.Setup(repo => repo.Get(null)).Returns(dests.AsQueryable());
            tripRepo.Setup(repo => repo.Get(null)).Returns(trips.AsQueryable());

            unitOfWork.Setup(w => w.Accommodations).Returns(accRepo.Object);
            unitOfWork.Setup(w => w.Activities).Returns(actRepo.Object);
            unitOfWork.Setup(w => w.Destinations).Returns(destRepo.Object);
            unitOfWork.Setup(w => w.Trips).Returns(tripRepo.Object);
            return unitOfWork;
        }

        public static Mock<IHttpContextAccessor> SetUpHttpContextAccessor()
        {
            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            var context = new Mock<HttpContext>();
            context.Setup(c => c.Session).Returns(new FakeSession());

            var session = new FakeSession();
            httpContextAccessor.Setup(a => a.HttpContext).Returns(context.Object);
            return httpContextAccessor;
        }

        #endregion
    }
}