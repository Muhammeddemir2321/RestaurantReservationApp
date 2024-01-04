using Reservation.Core.Models;
using Reservation.Core.Repositories;

namespace Reservation.Repository.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation.Core.Models.Reservation>, ITableRepository
    {
        public ReservationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
