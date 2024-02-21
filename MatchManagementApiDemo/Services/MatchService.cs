using AutoMapper;
using MatchManagementApiDemo.Data;
using MatchManagementApiDemo.Interfaces.Services;
using MatchManagementApiDemo.Models;
using MatchManagementApiDemo.Models.DTO;
using MatchManagementApiDemo.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchManagementApiDemo.Services
{
    /// <summary>
    /// Service class for managing matches.
    /// </summary>
    public class MatchService : BaseService<Match, MatchDto>, IMatchService
    {
        public MatchService(ApplicationDbContext applicationDbContext, IMapper mapper)
            : base(applicationDbContext, mapper)
        {

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
            return await GetMatchAsync(id);
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
            return await UpdateEntityAsync(id, matchDto);
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
