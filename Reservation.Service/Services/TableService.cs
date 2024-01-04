using AutoMapper;
using Microsoft.AspNetCore.Http;
using Reservation.Core.DTO_s;
using Reservation.Core.Models;
using Reservation.Core.Repositories;
using Reservation.Core.Services;
using Reservation.Core.UnitOfWorks;
using Reservation.Shared.DTO_s;

namespace Reservation.Service.Services
{
    public class TableService : GenericService<Table, TableDto>, ITableService
    {
        private readonly ITableRepository _tableRepository;
        public TableService(IGenericRepository<Table> repository, IMapper mapper, IUnitOfWork unitOfWork, ITableRepository tableRepository) : base(repository, mapper, unitOfWork)
        {
            _tableRepository = tableRepository;
        }

        public async Task<ResponseDto<List<TableDto>>> AvailableTablesAsync()
        {
            List<Table> availableTables = await _tableRepository.AvailableTablesAsync();
            List<TableDto> availableTablesDto = _mapper.Map<List<TableDto>>(availableTables);
            return ResponseDto<List<TableDto>>.Succes(availableTablesDto, StatusCodes.Status200OK);
        }
    }
}
