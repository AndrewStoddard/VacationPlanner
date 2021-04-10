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
    ///     Class DestinationConfig.
    ///     Implements the
    ///     <see
    ///         cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{AndrewStoddardVacationPlanner.Models.DomainModels.Destination}" />
    /// </summary>
    /// <seealso
    ///     cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{AndrewStoddardVacationPlanner.Models.DomainModels.Destination}" />
    public class DestinationConfig : IEntityTypeConfiguration<Destination>
    {
        #region Methods

        /// <summary>
        ///     Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
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