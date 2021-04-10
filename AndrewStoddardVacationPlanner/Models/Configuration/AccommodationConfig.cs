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
    ///     Class AccommodationConfig.
    ///     Implements the
    ///     <see
    ///         cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{AndrewStoddardVacationPlanner.Models.DomainModels.Accommodation}" />
    /// </summary>
    /// <seealso
    ///     cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{AndrewStoddardVacationPlanner.Models.DomainModels.Accommodation}" />
    public class AccommodationConfig : IEntityTypeConfiguration<Accommodation>
    {
        #region Methods

        /// <summary>
        ///     Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Accommodation> builder)
        {
            builder.HasKey(acc => acc.Id);
            builder.HasData(
                new Accommodation
                    {Id = 1, Name = "High-Rise Condo", Email = "book@highrise.com", PhoneNumber = "1234567890"},
                new Accommodation
                    {Id = 2, Name = "Low-Rise Condo", Email = "book@lowrise.com", PhoneNumber = "0987654321"},
                new Accommodation
                    {Id = 3, Name = "Motel 8", Email = "book@motel8.com", PhoneNumber = "5632147890"},
                new Accommodation
                    {Id = 4, Name = "Holiday Inn", Email = "book@holidayinn.com", PhoneNumber = "5823694170"}
            );
        }

        #endregion
    }
}