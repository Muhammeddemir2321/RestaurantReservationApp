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

        public async Task<ResponseDto<List<TableDto>>> AvailableTablesAsync(TableCheckDto tableCheckDto)
        {
            List<Table> availableTables = await _tableRepository.AvailableTablesAsync(tableCheckDto);
            List<TableDto> availableTablesDto = _mapper.Map<List<TableDto>>(availableTables);
            return ResponseDto<List<TableDto>>.Succes(availableTablesDto, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<TableDto>> AddAsync(TableCreateDto dto)
        {
            var newEntity = _mapper.Map<Table>(dto);
            await _tableRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = _mapper.Map<TableDto>(newEntity);
            return ResponseDto<TableDto>.Succes(newDto, StatusCodes.Status201Created);
        }
    }
}
