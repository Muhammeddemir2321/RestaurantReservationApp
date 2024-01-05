using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.Shared.DTO_s;

namespace Reservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ResponseDto<T> responce)
        {
            if (responce.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = responce.StatusCode };
            }

            return new ObjectResult(responce) { StatusCode = responce.StatusCode };
        }
    }
}
