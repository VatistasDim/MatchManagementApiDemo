using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchManagementApiDemo.Interfaces.BaseService
{
    public interface IBaseService<TEntity, TDto>
    {
        Task<IEnumerable<TDto>> GetEntitiesAsync();
        Task<TDto> GetEntityAsync(int id);
        Task<TDto> AddEntityAsync(TDto dto);
        Task<bool> UpdateEntityAsync(int id, TDto dto);
        Task<bool> DeleteEntityAsync(int id);
    }
}
