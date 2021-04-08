using AndrewStoddardVacationPlanner.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndrewStoddardVacationPlanner.Models.Configuration
{
    public class AccommodationConfig : IEntityTypeConfiguration<Accommodation>
    {
        #region Methods

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