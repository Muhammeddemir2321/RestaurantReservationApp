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
            builder.Property(x => x.TableNumber).IsRequired();
            builder.Property(x => x.ReservationDate).IsRequired();
            builder.Property(x => x.CustomerEmail).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CustomerName).IsRequired().HasMaxLength(50);
        }
    }
}
