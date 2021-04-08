using System.Collections.Generic;
using System.Linq;
using AndrewStoddardVacationPlanner.Models.DataAccessLayer;
using AndrewStoddardVacationPlanner.Models.DomainModels;
using AndrewStoddardVacationPlanner.Models.Enums;
using AndrewStoddardVacationPlanner.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AndrewStoddardVacationPlanner.Controllers
{
    public class VacationController : Controller
    {
        #region Data members

        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        #endregion

        #region Constructors

        public VacationController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        public IActionResult Home(int pageNumber = 1)
        {
            var pageSize = this.httpContextAccessor.HttpContext.Session.GetInt32("page_size") ?? 2;
            var trips = this.unitOfWork.Trips.Get().Include(t => t.Activities).Include(t => t.Destination)
                            .Include(t => t.Accommodation).ToList();
            if (this.httpContextAccessor.HttpContext.Session.GetInt32("sort_direction") ==
                (int) SortDirection.Ascending)
            {
                trips = this.orderAscending(trips);
            }
            else if (this.httpContextAccessor.HttpContext.Session.GetInt32("sort_direction") ==
                     (int) SortDirection.Descending)
            {
                trips = this.orderDescending(trips);
            }

            var totalPages = trips.Count / pageSize;
            totalPages += trips.Count % pageSize == 0 ? 0 : 1;
            var viewModel = new VacationListViewModel {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                Trips = trips
            };

            return View(viewModel);
        }

        private List<Trip> orderDescending(List<Trip> trips)
        {
            trips = this.httpContextAccessor.HttpContext.Session.GetInt32("sort_type") switch {
                1 => trips.OrderBy(trip => trip.Destination.Name).ToList(),
                2 => trips.OrderBy(trip => trip.StartDate).ToList(),
                3 => trips.OrderBy(trip => trip.EndDate).ToList(),
                4 => trips.OrderBy(trip => trip.Accommodation.Name).ToList(),
                5 => trips.OrderBy(trip => trip.Activities.Count).ToList()
            };
            return trips;
        }

        private List<Trip> orderAscending(List<Trip> trips)
        {
            trips = this.httpContextAccessor.HttpContext.Session.GetInt32("sort_type") switch {
                1 => trips.OrderByDescending(trip => trip.Destination.Name).ToList(),
                2 => trips.OrderByDescending(trip => trip.StartDate).ToList(),
                3 => trips.OrderByDescending(trip => trip.EndDate).ToList(),
                4 => trips.OrderByDescending(trip => trip.Accommodation.Name).ToList(),
                5 => trips.OrderByDescending(trip => trip.Activities.Count).ToList()
            };
            return trips;
        }

        [HttpPost]
        public IActionResult PageSize(int size)
        {
            this.httpContextAccessor.HttpContext.Session.SetInt32("page_size", size);
            return RedirectToAction("Home");
        }

        public IActionResult Sort(SortType sort)
        {
            this.httpContextAccessor.HttpContext.Session.SetInt32("sort_type", (int) sort);
            if (this.httpContextAccessor.HttpContext.Session.GetInt32("sort_direction") ==
                (int) SortDirection.Ascending)
            {
                this.httpContextAccessor.HttpContext.Session.SetInt32("sort_direction", (int) SortDirection.Descending);
            }
            else
            {
                this.httpContextAccessor.HttpContext.Session.SetInt32("sort_direction", (int) SortDirection.Ascending);
            }

            return RedirectToAction("Home");
        }

        #endregion
    }
}