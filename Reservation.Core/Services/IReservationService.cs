using Reservation.Core.DTO_s;
using Reservation.Shared.DTO_s;

namespace Reservation.Core.Services
{
    public interface IReservationService:IGenericService<Models.Reservation,ReservationDto>
    {
        Task<ResponseDto<ReservationCreateDto>> MakeReservation(ReservationCreateDto reservationCreateDto);
    }
}
