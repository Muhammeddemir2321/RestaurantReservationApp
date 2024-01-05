using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.Core.DTO_s;
using Reservation.Core.Services;

namespace Reservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : CustomBaseController
    {
        private readonly ITableService _tableService;
        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _tableService.GetAllAsync());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CheckTable([FromQuery] TableCheckDto tableCheck)
        {
             return CreateActionResult(await _tableService.AvailableTablesAsync(tableCheck));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _tableService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable(TableCreateDto tableCreateDto)
        {
            return CreateActionResult(await _tableService.AddAsync(tableCreateDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TableDto reservationUpdateDto)
        {
            return CreateActionResult(await _tableService.UpdateAsync(reservationUpdateDto));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _tableService.RemoveAsync(id));
        }
    }

}
