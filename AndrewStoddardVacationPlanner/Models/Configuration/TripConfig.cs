using System;
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
            builder.HasMany(trip => trip.Activities).WithMany(a => a.Trips);
            builder.HasData(
                new Trip {
                    Id = 1,
                    DestinationId = 6,
                    AccommodationId = 4,
                    StartDate = new DateTime(2019, 12, 20),
                    EndDate = new DateTime(2020, 1, 2)
                },
                new Trip {
                    Id = 2,
                    DestinationId = 2,
                    AccommodationId = 1,
                    StartDate = new DateTime(2020, 5, 23),
                    EndDate = new DateTime(2020, 6, 1)
                }
            );
        }

        #endregion
    }
}