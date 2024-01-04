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
        Task<List<Table>> AvailableTablesAsync();
        Task<bool> IsTableAvailableAsync(int id);
    }
}
