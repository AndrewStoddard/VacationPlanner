// ***********************************************************************
// Author           : Incendy
// Created          : 04-08-2021
//
// Last Modified By : Incendy
// Last Modified On : 04-08-2021
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using AndrewStoddardVacationPlanner.Models.DataAccessLayer;
using AndrewStoddardVacationPlanner.Models.DomainModels;
using AndrewStoddardVacationPlanner.Models.Enums;
using AndrewStoddardVacationPlanner.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AndrewStoddardVacationPlanner.Controllers
{
    /// <summary>
    ///     Class VacationController.
    ///     Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class VacationController : Controller
    {
        #region Data members

        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        ///     The HTTP context accessor
        /// </summary>
        private readonly IHttpContextAccessor httpContextAccessor;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="VacationController" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public VacationController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Homes the specified page number.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <returns>IActionResult.</returns>
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
            trips = trips.Skip((pageNumber - 1) * pageSize).Take(pageSize > trips.Count ? trips.Count : pageSize)
                         .ToList();

            var viewModel = new VacationListViewModel {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                Trips = trips
            };

            return View(viewModel);
        }

        /// <summary>
        ///     Adds the trip step1.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult AddTripStep1()
        {
            ViewBag.Destinations = this.unitOfWork.Destinations.Get().ToList();
            ViewBag.Accommodations = this.unitOfWork.Accommodations.Get().ToList();

            return View();
        }

        /// <summary>
        ///     Manages this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Manage()
        {
            return View(this.setupManageViewModel());
        }

        /// <summary>
        ///     Deletes the trip.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        public IActionResult DeleteTrip(int id)
        {
            var trip = this.unitOfWork.Trips.Get().Include(t => t.Destination).FirstOrDefault(t => t.Id == id);
            this.unitOfWork.Trips.Delete(trip);
            this.unitOfWork.Save();
            TempData["message"] = $"Deleted trip to {trip.Destination.Name} on {trip.StartDate.ToShortDateString()}.";
            return RedirectToAction("Home");
        }

        /// <summary>
        ///     Orders the descending.
        /// </summary>
        /// <param name="trips">The trips.</param>
        /// <returns>List&lt;Trip&gt;.</returns>
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

        /// <summary>
        ///     Orders the ascending.
        /// </summary>
        /// <param name="trips">The trips.</param>
        /// <returns>List&lt;Trip&gt;.</returns>
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

        /// <summary>
        ///     Pages the size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult PageSize(int size)
        {
            this.httpContextAccessor.HttpContext.Session.SetInt32("page_size", size);
            return RedirectToAction("Home");
        }

        /// <summary>
        ///     Sorts the specified sort.
        /// </summary>
        /// <param name="sort">The sort.</param>
        /// <returns>IActionResult.</returns>
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

        /// <summary>
        ///     Adds the trip step2.
        /// </summary>
        /// <param name="trip">The trip.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult AddTripStep2(Trip trip)
        {
            if (ModelState.IsValid)
            {
                TempData["trip_dest"] = trip.DestinationId;
                TempData["trip_acc"] = trip.AccommodationId;
                TempData["trip_start"] = trip.StartDate;
                TempData["trip_end"] = trip.EndDate;
                ViewBag.Activities = this.unitOfWork.Activities.Get().ToList();

                return View();
            }

            ViewBag.Destinations = this.unitOfWork.Destinations.Get().ToList();
            ViewBag.Accommodations = this.unitOfWork.Accommodations.Get().ToList();
            return View("AddTripStep1", trip);
        }

        /// <summary>
        ///     Adds the trip.
        /// </summary>
        /// <param name="activities">The activities.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult AddTrip(int[] activities)
        {
            var trip = new Trip {
                DestinationId = (int) TempData["trip_dest"],
                AccommodationId = (int) TempData["trip_acc"],
                StartDate = (DateTime) TempData["trip_start"],
                EndDate = (DateTime) TempData["trip_end"]
            };
            trip.Activities = new List<Activity>();
            foreach (var activityid in activities)
            {
                trip.Activities.Add(this.unitOfWork.Activities.Get().FirstOrDefault(a => a.Id == activityid));
            }

            this.unitOfWork.Trips.Insert(trip);
            this.unitOfWork.Save();

            TempData["message"] =
                $"Trip for {this.unitOfWork.Destinations.Get().FirstOrDefault(t => t.Id == trip.DestinationId).Name} on {trip.StartDate.ToShortDateString()}";

            return RedirectToAction("Home");
        }

        /// <summary>
        ///     Adds from manage.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult AddFromManage(ManageViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.AccommodationName) &&
                string.IsNullOrEmpty(viewModel.AccommodationEmail) &&
                string.IsNullOrEmpty(viewModel.AccommodationPhone) && string.IsNullOrEmpty(viewModel.ActivityName) &&
                !string.IsNullOrEmpty(viewModel.DestinationName))
            {
                this.unitOfWork.Destinations.Insert(new Destination {Name = viewModel.DestinationName});
                this.unitOfWork.Save();
                TempData["message"] = $"Added {viewModel.DestinationName} to destinations";
                return RedirectToAction("Home");
            }

            if (string.IsNullOrEmpty(viewModel.AccommodationName) &&
                string.IsNullOrEmpty(viewModel.AccommodationEmail) &&
                string.IsNullOrEmpty(viewModel.AccommodationPhone) && !string.IsNullOrEmpty(viewModel.ActivityName) &&
                string.IsNullOrEmpty(viewModel.DestinationName))
            {
                this.unitOfWork.Activities.Insert(new Activity {Name = viewModel.ActivityName});
                this.unitOfWork.Save();
                TempData["message"] = $"Added {viewModel.ActivityName} to activities";
                return RedirectToAction("Home");
            }

            if ((!string.IsNullOrEmpty(viewModel.AccommodationName) ||
                 !string.IsNullOrEmpty(viewModel.AccommodationEmail) ||
                 !string.IsNullOrEmpty(viewModel.AccommodationPhone)) && string.IsNullOrEmpty(viewModel.ActivityName) &&
                string.IsNullOrEmpty(viewModel.DestinationName))
            {
                var phone = viewModel.AccommodationPhone;
                if (!string.IsNullOrEmpty(phone))
                {
                    phone = Regex.Replace(phone, @"[^0-9]+", "");
                    if (phone.Length != 10)
                    {
                        TempData["message"] = "Phone number is invalid";
                        return RedirectToAction("Manage");
                    }
                }

                if (!string.IsNullOrEmpty(viewModel.AccommodationEmail))
                {
                    if (!new EmailAddressAttribute().IsValid(viewModel.AccommodationEmail))
                    {
                        TempData["message"] = "Email is invalid";
                        return RedirectToAction("Manage");
                    }
                }

                this.unitOfWork.Accommodations.Insert(new Accommodation {
                    Name = viewModel.AccommodationName, Email = viewModel.AccommodationEmail,
                    PhoneNumber = viewModel.AccommodationPhone
                });
                this.unitOfWork.Save();
                TempData["message"] = $"Added {viewModel.AccommodationName} to accommodations";
                return RedirectToAction("Home");
            }

            if (string.IsNullOrEmpty(viewModel.AccommodationName) &&
                string.IsNullOrEmpty(viewModel.AccommodationEmail) &&
                string.IsNullOrEmpty(viewModel.AccommodationPhone) && string.IsNullOrEmpty(viewModel.ActivityName) &&
                string.IsNullOrEmpty(viewModel.DestinationName))
            {
                TempData["message"] = "You need to add a destination, accommodation name, or activity";
                return RedirectToAction("Manage");
            }

            TempData["dest_name"] = viewModel.DestinationName;
            TempData["acc_name"] = viewModel.AccommodationName;
            TempData["acc_email"] = viewModel.AccommodationEmail;
            TempData["acc_phone"] = viewModel.AccommodationPhone;
            TempData["act_name"] = viewModel.ActivityName;
            TempData["message"] = "You can only add 1 item at a time. Please remove the fields you do not wish to add";
            return RedirectToAction("Manage");
        }

        /// <summary>
        ///     Deletes from manage.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult DeleteFromManage(ManageViewModel viewModel)
        {
            if (viewModel.SelectedAccommodationToDelete != 0 && viewModel.SelectedActivityToDelete == 0 &&
                viewModel.SelectedDestinationToDelete == 0)
            {
                var accommodation = this.unitOfWork.Accommodations.Get()
                                        .FirstOrDefault(a => a.Id == viewModel.SelectedAccommodationToDelete);
                TempData["message"] = $"Deleted {accommodation.Name} from the accommodations";
                this.unitOfWork.Accommodations.Delete(accommodation);
                this.unitOfWork.Save();
                return RedirectToAction("Home");
            }

            if (viewModel.SelectedAccommodationToDelete == 0 && viewModel.SelectedActivityToDelete != 0 &&
                viewModel.SelectedDestinationToDelete == 0)
            {
                var activity = this.unitOfWork.Activities.Get()
                                   .FirstOrDefault(a => a.Id == viewModel.SelectedActivityToDelete);
                TempData["message"] = $"Deleted {activity.Name} from the activities";
                this.unitOfWork.Activities.Delete(activity);
                this.unitOfWork.Save();
                return RedirectToAction("Home");
            }

            if (viewModel.SelectedAccommodationToDelete == 0 && viewModel.SelectedActivityToDelete == 0 &&
                viewModel.SelectedDestinationToDelete != 0)
            {
                var destination = this.unitOfWork.Destinations.Get()
                                      .FirstOrDefault(d => d.Id == viewModel.SelectedDestinationToDelete);
                TempData["message"] = $"Deleted {destination.Name} from the destinations";
                this.unitOfWork.Destinations.Delete(destination);
                this.unitOfWork.Save();
                return RedirectToAction("Home");
            }

            if (viewModel.SelectedAccommodationToDelete == 0 && viewModel.SelectedActivityToDelete == 0 &&
                viewModel.SelectedDestinationToDelete == 0)
            {
                TempData["message"] = "You need to select a destination, accommodation, or activity to delete";
                return RedirectToAction("Manage");
            }

            TempData["message"] = "You can only delete one destination, accommodation, or activity at a time.";

            return RedirectToAction("Manage");
        }

        /// <summary>
        ///     Setups the manage view model.
        /// </summary>
        /// <returns>ManageViewModel.</returns>
        private ManageViewModel setupManageViewModel()
        {
            var viewModel = new ManageViewModel {
                DestinationName = (string) TempData["dest_name"] ?? "",
                AccommodationName = (string) TempData["acc_name"] ?? "",
                AccommodationEmail = (string) TempData["acc_email"] ?? "",
                AccommodationPhone = (string) TempData["acc_phone"] ?? "",
                ActivityName = (string) TempData["act_name"] ?? "",
                Destinations = this.unitOfWork.Destinations.Get().ToList(),
                Accommodations = this.unitOfWork.Accommodations.Get().ToList(),
                Activities = this.unitOfWork.Activities.Get().ToList(),
                SelectedAccommodationToDelete = 0,
                SelectedActivityToDelete = 0,
                SelectedDestinationToDelete = 0
            };
            return viewModel;
        }

        #endregion
    }
}