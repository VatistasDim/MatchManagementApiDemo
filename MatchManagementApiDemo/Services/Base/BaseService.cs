using AutoMapper;
using MatchManagementApiDemo.Data;
using MatchManagementApiDemo.Interfaces.BaseService;
using MatchManagementApiDemo.Interfaces.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementApiDemo.Services.Base
{
    public class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {

        protected readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public BaseService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<TDto> AddEntityAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _applicationDbContext.Set<TEntity>().Add(entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }

        public async Task<bool> DeleteEntityAsync(int id)
        {
            var entity = await _applicationDbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
                return false;

            _applicationDbContext.Set<TEntity>().Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TDto>> GetEntitiesAsync()
        {
            var entities = await _applicationDbContext.Set<TEntity>().ToListAsync();
            return entities.Select(e => _mapper.Map<TDto>(e));
        }

        public async Task<TDto> GetEntityAsync(int id)
        {
            var entity = await _applicationDbContext.Set<TEntity>().FindAsync(id);
            return entity != null ? _mapper.Map<TDto>(entity) : null;
        }

        public async Task<bool> UpdateEntityAsync(int id, TDto dto)
        {
            var existingEntity = await _applicationDbContext.Set<TEntity>().FindAsync(id);

            if (existingEntity == null)
                return false;

            _mapper.Map(dto, existingEntity);

            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
