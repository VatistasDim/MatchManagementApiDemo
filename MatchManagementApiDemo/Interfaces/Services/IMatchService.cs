using MatchManagementApiDemo.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchManagementApiDemo.Interfaces.Services
{
    /// <summary>
    /// Interface for managing matches.
    /// </summary>
    public interface IMatchService
    {
        /// <summary>
        /// Gets all matches.
        /// </summary>
        /// <returns>A collection of match DTOs.</returns>
        Task<IEnumerable<MatchDto>> GetMatchesAsync();

        /// <summary>
        /// Gets a match by its ID.
        /// </summary>
        /// <param name="id">The ID of the match.</param>
        /// <returns>The match DTO if found, otherwise null.</returns>
        Task<MatchDto> GetMatchAsync(int id);

        /// <summary>
        /// Adds a new match.
        /// </summary>
        /// <param name="matchDto">The match DTO to be added.</param>
        /// <returns>The added match DTO.</returns>
        Task<MatchDto> AddMatchAsync(MatchDto matchDto);

        /// <summary>
        /// Updates an existing match.
        /// </summary>
        /// <param name="id">The ID of the match to be updated.</param>
        /// <param name="matchDto">The updated match DTO.</param>
        /// <returns>True if the update is successful, otherwise false.</returns>
        Task<bool> UpdateMatchAsync(int id, MatchDto matchDto);

        /// <summary>
        /// Deletes a match by its ID.
        /// </summary>
        /// <param name="id">The ID of the match to be deleted.</param>
        /// <returns>True if the deletion is successful, otherwise false.</returns>
        Task<bool> DeleteMatchAsync(int id);
    }
}
