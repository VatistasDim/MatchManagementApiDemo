using MatchManagementApiDemo.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchManagementApiDemo.Interfaces.Services
{
    public interface IMatchOddsService
    {
        Task<IEnumerable<MatchOddsDto>> GetMatchOddsAsync();
        Task<MatchOddsDto> GetMatchOddsAsync(int id);
        Task<MatchOddsDto> AddMatchOddsAsync(MatchOddsDto matchOddsDto);
        Task<bool> UpdateMatchOddsAsync(int id, MatchOddsDto matchOddsDto);
        Task<bool> DeleteMatchOddsAsync(int id);
    }
}
