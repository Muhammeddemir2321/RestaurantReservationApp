using Microsoft.EntityFrameworkCore;
using Reservation.Core.DTO_s;
using Reservation.Core.Models;
using Reservation.Core.Repositories;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Reservation.Repository.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        
        public TableRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Table>> AvailableTablesAsync(TableCheckDto tableCheckDto)
        {
            var reservedTableNumbers = await _context.Reservations.Where(r => r.ReservationDate < tableCheckDto.ReservationDate)
                                .Select(r => r.TableNumber).ToListAsync();

            List<Table> availabletables = await _context.Tables.Where(i => i.IsActive && i.Capacity > tableCheckDto.Capacity && reservedTableNumbers.Contains(i.Number)).ToListAsync();

            return availabletables;

        }

        public async Task<bool> IsTableAvailableAsync(int tableNumber,int capacity, DateTime date)
        {
            //var query = from r in _context.Reservations
            //            join t in _context.Tables on r.TableNumber equals t.Number
            //            where (t.IsActive==true && r.TableNumber == tableNumber && t.Capacity >= capacity && r.ReservationDate > date)
            //            select t;

            //var IsAvailable= await query.AnyAsync(); 
            //return IsAvailable;


            //var isAvailable = await _context.Reservations
            //.Where(r => r.TableNumber == tableNumber && r.ReservationDate > date)
            //.Join(_context.Tables, r => r.TableNumber, t => t.Number, (r, t) => t.IsActive==true &&t.Capacity>=capacity)
            //.AnyAsync();
            //return isAvailable;


            var isAvailable = !await _context.Reservations
            .AnyAsync(r => r.TableNumber == tableNumber && r.ReservationDate == date);

            return isAvailable;
        }


       
    }
}
