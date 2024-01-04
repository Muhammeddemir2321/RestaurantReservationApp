using Microsoft.EntityFrameworkCore;
using Reservation.Core.Models;
using Reservation.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Repository.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        
        public TableRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Table>> AvailableTablesAsync()
        {
            var reservedTableNumbers = await _context.Reservations.Select(x=> x.TableNumber).ToListAsync();
            List<Table> availabletables = await _context.Tables.Where(i => i.Status && reservedTableNumbers.Contains(i.Number)).ToListAsync();

            return availabletables;
        }

        public Task<bool> IsTableAvailableAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
