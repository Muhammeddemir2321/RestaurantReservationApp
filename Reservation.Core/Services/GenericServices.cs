using Reservation.Shared.DTO_s;
using System.Linq.Expressions;

namespace Reservation.Core.Services
{
    public interface IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<ResponseDto<IEnumerable<TDto>>> GetAllAsync();
        Task<ResponseDto<TDto>> GetByIdAsync(int id);
        Task<ResponseDto<IEnumerable<TDto>>> AddRangeAsync(IEnumerable<TDto> dtos);
        Task<ResponseDto<TDto>> AddAsync(TDto dto);
        Task<ResponseDto<NoContent>> UpdateAsync(TDto dto);
        Task<ResponseDto<NoContent>> RemoveAsync(int id);
        Task<ResponseDto<NoContent>> RemoveRangeAsync(IEnumerable<int> ids);
    }
}
