using AndrewStoddardVacationPlanner.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndrewStoddardVacationPlanner.Models.Configuration
{
    public class ActivityConfig : IEntityTypeConfiguration<Activity>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(activity => activity.Id);
            builder.HasData(
                new Activity {Id = 1, Name = "SkyDiving"},
                new Activity {Id = 2, Name = "Parasail"},
                new Activity {Id = 3, Name = "Go Karts"},
                new Activity {Id = 4, Name = "Mini Golf"},
                new Activity {Id = 5, Name = "Mountain Hiking"},
                new Activity {Id = 6, Name = "Deep Sea Fishing"}
            );
        }

        #endregion
    }
}