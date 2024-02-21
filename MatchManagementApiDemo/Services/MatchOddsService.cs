using MatchManagementApiDemo.Data;
using MatchManagementApiDemo.Interfaces.Mapper;
using MatchManagementApiDemo.Interfaces.Services;
using MatchManagementApiDemo.Models;
using MatchManagementApiDemo.Models.DTO;
using MatchManagementApiDemo.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchManagementApiDemo.Services
{
    public class MatchOddsService : BaseService<MatchOdds, MatchOddsDto>, IMatchOddsService
    {

        public MatchOddsService(ApplicationDbContext applicationDbContext, IEntityMapper<MatchOdds, MatchOddsDto> entityMapper)
            : base(applicationDbContext, entityMapper)
        {

        }

        public async Task<IEnumerable<MatchOddsDto>> GetMatchOddsAsync()
        {
            return await GetEntitiesAsync();
        }

        public async Task<MatchOddsDto> GetMatchOddsAsync(int id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<MatchOddsDto> AddMatchOddsAsync(MatchOddsDto matchOddsDto)
        {
            return await AddEntityAsync(matchOddsDto);
        }

        public async Task<bool> UpdateMatchOddsAsync(int id, MatchOddsDto matchOddsDto)
        {
            return await UpdateEntityAsync(id, matchOddsDto);
        }

        public async Task<bool> DeleteMatchOddsAsync(int id)
        {
            return await DeleteEntityAsync(id);
        }
    }
}
