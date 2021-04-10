// ***********************************************************************
// Author           : Incendy
// Created          : 04-08-2021
//
// Last Modified By : Incendy
// Last Modified On : 04-08-2021
// ***********************************************************************

using AndrewStoddardVacationPlanner.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndrewStoddardVacationPlanner.Models.Configuration
{
    /// <summary>
    ///     Class ActivityConfig.
    ///     Implements the
    ///     <see
    ///         cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{AndrewStoddardVacationPlanner.Models.DomainModels.Activity}" />
    /// </summary>
    /// <seealso
    ///     cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{AndrewStoddardVacationPlanner.Models.DomainModels.Activity}" />
    public class ActivityConfig : IEntityTypeConfiguration<Activity>
    {
        #region Methods

        /// <summary>
        ///     Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(activity => activity.Id);
            builder.HasMany(a => a.Trips).WithMany(t => t.Activities);
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