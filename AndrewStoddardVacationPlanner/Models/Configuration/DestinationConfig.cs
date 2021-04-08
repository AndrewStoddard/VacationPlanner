using AndrewStoddardVacationPlanner.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndrewStoddardVacationPlanner.Models.Configuration
{
    public class DestinationConfig : IEntityTypeConfiguration<Destination>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.HasKey(destination => destination.Id);
            builder.HasData(
                new Destination {Id = 1, Name = "Orlando, Florida"},
                new Destination {Id = 2, Name = "Panama City, Florida"},
                new Destination {Id = 3, Name = "Orange Beach, Alabama"},
                new Destination {Id = 4, Name = "Helen, Georgia"},
                new Destination {Id = 5, Name = "New York City, New York"},
                new Destination {Id = 6, Name = "Gatlinburg, Tennessee"}
            );
        }

        #endregion
    }
}