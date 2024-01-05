using Reservation.Core.Models;
using Reservation.Core.Repositories;

namespace Reservation.Repository.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation.Core.Models.Reservation>, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context)
        {
        }

       
    }
}
