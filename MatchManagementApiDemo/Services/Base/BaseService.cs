using AutoMapper;
using MatchManagementApiDemo.Data;
using MatchManagementApiDemo.Interfaces.BaseService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementApiDemo.Services.Base
{
    /// <summary>
    /// Base service providing common CRUD operations for entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDto">The type of the DTO (Data Transfer Object).</typeparam>
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

        /// <summary>
        /// Adds a new entity to the database based on the provided DTO.
        /// </summary>
        /// <param name="dto">The Data Transfer Object (DTO) representing the entity.</param>
        /// <returns>
        /// A Task representing the asynchronous operation. The task result contains the DTO
        /// representing the added entity.
        /// </returns>
        public async Task<TDto> AddEntityAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _applicationDbContext.Set<TEntity>().Add(entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }

        /// <summary>
        /// Deletes an entity from the database based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to be deleted.</param>
        /// <returns>
        /// A Task representing the asynchronous operation. The task result is a boolean indicating
        /// whether the deletion was successful (true) or the entity with the given ID was not found (false).
        /// </returns>
        public async Task<bool> DeleteEntityAsync(int id)
        {
            var entity = await _applicationDbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
                return false;

            _applicationDbContext.Set<TEntity>().Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Retrieves all entities of the specified type from the database.
        /// </summary>
        /// <returns>
        /// A Task representing the asynchronous operation. The task result is an IEnumerable of DTOs
        /// representing the retrieved entities.
        /// </returns>
        public async Task<IEnumerable<TDto>> GetEntitiesAsync()
        {
            var entities = await _applicationDbContext.Set<TEntity>().ToListAsync();
            return entities.Select(e => _mapper.Map<TDto>(e));
        }

        /// <summary>
        /// Retrieves an entity of the specified type from the database based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to retrieve.</param>
        /// <returns>
        /// A Task representing the asynchronous operation. The task result is a DTO representing the retrieved entity,
        /// or null if no entity is found with the specified identifier.
        /// </returns>
        public async Task<TDto> GetEntityAsync(int id)
        {
            var entity = await _applicationDbContext.Set<TEntity>().FindAsync(id);
            return entity != null ? _mapper.Map<TDto>(entity) : null;
        }

        /// <summary>
        /// Updates an existing entity in the database with the provided data.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to update.</param>
        /// <param name="dto">The data transfer object (DTO) containing the updated information.</param>
        /// <returns>
        /// A Task representing the asynchronous operation. The task result is a boolean indicating
        /// whether the update operation was successful (true) or if the entity with the specified
        /// identifier was not found (false).
        /// </returns>
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
