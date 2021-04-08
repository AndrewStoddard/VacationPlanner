using System;
using System.Collections.Generic;
using AndrewStoddardVacationPlanner.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndrewStoddardVacationPlanner.Models.Configuration
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(trip => trip.Id);
            builder.HasMany(trip => trip.Activities);
            builder.HasData(
                new Trip {
                    Id = 1,
                    DestinationId = 6,
                    AccommodationId = 4,
                    StartDate = new DateTime(2019, 12, 20),
                    EndDate = new DateTime(2020, 1, 2),
                    Activities = new List<Activity> {new() {Id = 4, Name = "Mini Golf"}}
                },
                new Trip {
                    Id = 2,
                    DestinationId = 2,
                    AccommodationId = 1,
                    StartDate = new DateTime(2020, 5, 23),
                    EndDate = new DateTime(2020, 6, 1),
                    Activities = new List<Activity> {new() {Id = 1, Name = "Skydiving"}}
                }
            );
        }

        #endregion
    }
}