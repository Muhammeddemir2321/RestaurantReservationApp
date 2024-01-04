using AutoMapper;
using Reservation.Core.DTO_s;
using Reservation.Core.Repositories;
using Reservation.Core.Services;
using Reservation.Core.UnitOfWorks;
using Reservation.Shared.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Service.Services
{
    public class ReservationService : GenericService<Core.Models.Reservation, ReservationDto>, IReservationService
    {
        public ReservationService(IGenericRepository<Core.Models.Reservation> repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

        public Task<ResponseDto<ReservationCreateDto>> MakeReservation(ReservationCreateDto reservationCreateDto)
        {
            throw new NotImplementedException();
        }
    }
}
