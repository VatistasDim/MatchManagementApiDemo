using AutoMapper;
using MatchManagementApiDemo.Data;
using MatchManagementApiDemo.Interfaces.Services;
using MatchManagementApiDemo.Models;
using MatchManagementApiDemo.Models.DTO;
using MatchManagementApiDemo.Services.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementApiDemo.Services
{
    /// <summary>
    /// Service class for managing matches.
    /// </summary>
    public class MatchService : BaseService<Match, MatchDto>, IMatchService
    {
        private readonly IMapper _mapper;
        public MatchService(ApplicationDbContext applicationDbContext, IMapper mapper)
            : base(applicationDbContext, mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets all matches.
        /// </summary>
        /// <returns>A collection of match DTOs.</returns>
        public async Task<IEnumerable<MatchDto>> GetMatchesAsync()
        {
            return await GetMatchesAsync();
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets a match by its ID.
        /// </summary>
        /// <param name="id">The ID of the match.</param>
        /// <returns>The match DTO if found, otherwise null.</returns>
        public async Task<MatchDto> GetMatchAsync(int id)
        {
            return await GetEntityAsync(id);
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets a match by its ID.
        /// </summary>
        /// <param name="id">The ID of the match.</param>
        /// <returns>The match DTO if found, otherwise null.</returns>
        public async Task<MatchDto> AddMatchAsync(MatchDto matchDto)
        {
            return await AddEntityAsync(matchDto);
        }

        /// <inheritdoc/>
        /// <summary>
        /// Updates an existing match.
        /// </summary>
        /// <param name="id">The ID of the match to be updated.</param>
        /// <param name="matchDto">The updated match DTO.</param>
        /// <returns>True if the update is successful, otherwise false.</returns>
        public async Task<bool> UpdateMatchAsync(int id, MatchDto matchDto)
        {
            var existingMatch = await _applicationDbContext.Matches
                            .Include(m => m.MatchOdds)
                            .FirstOrDefaultAsync(m => m.ID == id);

            if (existingMatch == null)
                return false;

            var mapOptions = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MatchDto, Match>().ForMember(dest => dest.ID, opt => opt.Ignore());
                cfg.CreateMap<MatchOddsDto, MatchOdds>().ForMember(dest => dest.ID, opt => opt.Ignore());
            }).CreateMapper();
            mapOptions.Map(matchDto, existingMatch);
            if (matchDto.MatchOdds != null && matchDto.MatchOdds.Any())
            {
                foreach (var matchOddsDto in matchDto.MatchOdds)
                {
                    var existingMatchOdds = existingMatch.MatchOdds.FirstOrDefault(mo => mo.ID == matchOddsDto.ID);

                    if (existingMatchOdds != null)
                    {
                        mapOptions.Map(matchOddsDto, existingMatchOdds);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Deletes a match by its ID.
        /// </summary>
        /// <param name="id">The ID of the match to be deleted.</param>
        /// <returns>True if the deletion is successful, otherwise false.</returns>
        public async Task<bool> DeleteMatchAsync(int id)
        {
            return await DeleteEntityAsync(id);
        }
    }
}
