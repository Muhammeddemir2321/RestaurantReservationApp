using Reservation.Core.DTO_s;
using Reservation.Core.Models;
using Reservation.Shared.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Repositories
{
    public interface ITableRepository:IGenericRepository<Table>
    {
        Task<List<Table>> AvailableTablesAsync(TableCheckDto tableCheckDto);
        Task<bool> IsTableAvailableAsync(int tableNumber, int capacity, DateTime date);
    }
}
