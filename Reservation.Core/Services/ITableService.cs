using Reservation.Core.DTO_s;
using Reservation.Core.Models;
using Reservation.Shared.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Services
{
    public interface ITableService:IGenericService<Table,TableDto>
    {
        Task<ResponseDto<List<TableDto>>> AvailableTablesAsync(TableCheckDto tableCheckDto);

        Task<ResponseDto<TableDto>> AddAsync(TableCreateDto dto);
    }
}
