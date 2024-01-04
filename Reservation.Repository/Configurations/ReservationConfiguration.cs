using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Reservation.Repository.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Core.Models.Reservation>
    {
        public void Configure(EntityTypeBuilder<Core.Models.Reservation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.NumberOfGuests).IsRequired().HasMaxLength(50);
        }
    }
}
