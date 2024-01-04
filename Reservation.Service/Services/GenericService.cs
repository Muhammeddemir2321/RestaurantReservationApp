using Reservation.Core.Services;
using Reservation.Shared.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Service.Services
{
    public class GenericService<Tentity, TDto> : IGenericService<Tentity, TDto> where Tentity : class where TDto : class
    {
        public Task<ResponseDto<TDto>> AddAsync(TDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<IEnumerable<TDto>>> AddRangeAsync(IEnumerable<TDto> dtos)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<IEnumerable<TDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<TDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<NoContent>> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<NoContent>> RemoveRangeAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<NoContent>> UpdateAsync(TDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
