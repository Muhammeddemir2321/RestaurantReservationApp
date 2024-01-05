using AutoMapper;
using Microsoft.AspNetCore.Http;
using Reservation.Core.DTO_s;
using Reservation.Core.Repositories;
using Reservation.Core.Services;
using Reservation.Core.UnitOfWorks;
using Reservation.Service.MailServices;
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
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IMailService _mailService;
        public ReservationService(IGenericRepository<Core.Models.Reservation> repository, IMapper mapper, IUnitOfWork unitOfWork, ITableRepository tableRepository, IReservationRepository reservationRepository, IMailService mailService) : base(repository, mapper, unitOfWork)
        {
            _tableRepository = tableRepository;
            _reservationRepository = reservationRepository;
            _mailService = mailService;
        }

        public async Task<ResponseDto<ReservationCreateDto>> MakeReservation(ReservationCreateDto reservationCreateDto)
        {
            var isAvailable = await _tableRepository.IsTableAvailableAsync(reservationCreateDto.TableNumber, reservationCreateDto.NumberOfGuests,reservationCreateDto.ReservationDate);

            if (!isAvailable)
            {
                return ResponseDto<ReservationCreateDto>.Fail($"{reservationCreateDto.TableNumber} numaralı masa müsait değil !", StatusCodes.Status404NotFound,true);
            }
            var entity=_mapper.Map<Core.Models.Reservation>(reservationCreateDto);
            await _reservationRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            string message = $"{reservationCreateDto.CustomerName} müşterisine {reservationCreateDto.TableNumber} numaralı masa  rezervasyonu {reservationCreateDto.ReservationDate} tarihli oluşturuldu";

            await _mailService.SendMail(reservationCreateDto.CustomerEmail,"Reservasyon Onayı",message);
            
            return ResponseDto<ReservationCreateDto>.Succes(reservationCreateDto, StatusCodes.Status201Created);
        }
    }
}
