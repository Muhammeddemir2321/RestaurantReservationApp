using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.Core.DTO_s;
using Reservation.Core.Services;

namespace Reservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : CustomBaseController
    {
        private readonly IReservationService _reservationService;
        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _reservationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _reservationService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> MakeReservation(ReservationCreateDto reservationCreateDto)
        {
            return CreateActionResult(await _reservationService.MakeReservation(reservationCreateDto));
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveReservation(int id)
        {
            return CreateActionResult(await _reservationService.RemoveAsync(id));
        }
    }
}
