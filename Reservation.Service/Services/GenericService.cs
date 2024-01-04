﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Reservation.Core.Repositories;
using Reservation.Core.Services;
using Reservation.Core.UnitOfWorks;
using Reservation.Shared.DTO_s;

namespace Reservation.Service.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<TDto>> AddAsync(TDto dto)
        {
            var newEntity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = _mapper.Map<TDto>(newEntity);
            return ResponseDto<TDto>.Succes(newDto, StatusCodes.Status201Created);
        }

        public async Task<ResponseDto<IEnumerable<TDto>>> AddRangeAsync(IEnumerable<TDto> dtos)
        {
            var newEntities = _mapper.Map<IEnumerable<TEntity>>(dtos);
            await _repository.AddRangeAsync(newEntities);
            await _unitOfWork.CommitAsync();
            var newDtos = _mapper.Map<List<TDto>>(newEntities);
            return ResponseDto<IEnumerable<TDto>>.Succes(newDtos, StatusCodes.Status201Created);
        }

        public async Task<ResponseDto<IEnumerable<TDto>>> GetAllAsync()
        {
            var entities = await _repository.GetAll().ToListAsync();
            var dto = _mapper.Map<List<TDto>>(entities);
            return ResponseDto<IEnumerable<TDto>>.Succes(dto, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<TDto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return ResponseDto<TDto>.Fail("not found id", StatusCodes.Status404NotFound, true);
            var dto = _mapper.Map<TDto>(entity);
            return ResponseDto<TDto>.Succes(dto, StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<NoContent>> RemoveAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return ResponseDto<NoContent>.Fail("not found id", StatusCodes.Status404NotFound, true);
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            return ResponseDto<NoContent>.Succes(StatusCodes.Status204NoContent);
        }

        public async Task<ResponseDto<NoContent>> RemoveRangeAsync(IEnumerable<int> ids)
        {
            var entities = await _repository.GetByIdsAsync(ids);
            if (entities == null)
                return ResponseDto<NoContent>.Fail("not found id", StatusCodes.Status404NotFound, true);
            _repository.Remove(entities);
            await _unitOfWork.CommitAsync();
            return ResponseDto<NoContent>.Succes(StatusCodes.Status204NoContent);
        }

        public async Task<ResponseDto<NoContent>> UpdateAsync(TDto dto)
        {
            var newEntity = _mapper.Map<TEntity>(dto);
            _repository.Update(newEntity);
            await _unitOfWork.CommitAsync();
            return ResponseDto<NoContent>.Succes(StatusCodes.Status204NoContent);
        }
    }
}
