using AutoMapper;
using MatchManagementApiDemo.Data;
using MatchManagementApiDemo.Interfaces.Services;
using MatchManagementApiDemo.Models;
using MatchManagementApiDemo.Models.DTO;
using MatchManagementApiDemo.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchManagementApiDemo.Services
{
    public class MatchOddsService : BaseService<MatchOdds, MatchOddsDto>, IMatchOddsService
    {
        private readonly IMapper _mapper;
        public MatchOddsService(ApplicationDbContext applicationDbContext, IMapper mapper)
            : base(applicationDbContext, mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all match odds from the database.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation. The task result is a collection of MatchOddsDto.</returns>
        public async Task<IEnumerable<MatchOddsDto>> GetMatchOddsAsync()
        {
            return await GetEntitiesAsync();
        }

        /// <summary>
        /// Retrieves a specific match odds by its unique identifier from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the match odds.</param>
        /// <returns>
        /// A Task representing the asynchronous operation. The task result is MatchOddsDto if found,
        /// or null if no match odds with the specified identifier is found.
        /// </returns>
        public async Task<MatchOddsDto> GetMatchOddsAsync(int id)
        {
            return await GetEntityAsync(id);
        }

        /// <summary>
        /// Adds a new match odds entry to the database.
        /// </summary>
        /// <param name="matchOddsDto">The data transfer object (DTO) containing information about the match odds.</param>
        /// <returns>
        /// A Task representing the asynchronous operation. The task result is MatchOddsDto representing
        /// the newly added match odds entry.
        /// </returns>
        /// <exception cref="Exception">Thrown if the associated match for the odds is not found in the database.</exception>
        public async Task<MatchOddsDto> AddMatchOddsAsync(MatchOddsDto matchOddsDto)
        {
            
            var matchOddsEntity = _mapper.Map<MatchOdds>(matchOddsDto);
            var matchEntity = await _applicationDbContext.Matches
                .FirstOrDefaultAsync(m => m.ID == matchOddsDto.MatchId);

            if (matchEntity == null)
                throw new Exception("Match not found");
            matchOddsEntity.Match = matchEntity;
            _applicationDbContext.Set<MatchOdds>().Add(matchOddsEntity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<MatchOddsDto>(matchOddsEntity);
        }

        /// <summary>
        /// Updates an existing match odds entry in the database with the provided data.
        /// </summary>
        /// <param name="id">The unique identifier of the match odds entry to update.</param>
        /// <param name="matchOddsDto">The data transfer object (DTO) containing the updated information.</param>
        /// <returns>
        /// A Task representing the asynchronous operation. The task result is a boolean indicating
        /// whether the update operation was successful (true) or if the match odds entry with the specified
        /// identifier was not found (false).
        /// </returns>
        public async Task<bool> UpdateMatchOddsAsync(int id, MatchOddsDto matchOddsDto)
        {
            var existingMatchOdds = await _applicationDbContext.Set<MatchOdds>().FindAsync(id);

            if (existingMatchOdds == null)
                return false;
            var mapOptions = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MatchOddsDto, MatchOdds>().ForMember(dest => dest.ID, opt => opt.Ignore());
                cfg.CreateMap<MatchDto, Match>().ForMember(dest => dest.ID, opt => opt.Ignore());
            }).CreateMapper();
            mapOptions.Map(matchOddsDto, existingMatchOdds);
            if (matchOddsDto.Match != null)
            {
                var existingMatch = await _applicationDbContext.Matches.FindAsync(matchOddsDto.Match.ID);

                if (existingMatch != null)
                {
                    mapOptions.Map(matchOddsDto.Match, existingMatch);
                }
            }

            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Deletes a match odds entry from the database based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the match odds entry to delete.</param>
        /// <returns>
        /// A Task representing the asynchronous operation. The task result is a boolean indicating
        /// whether the deletion operation was successful (true) or if the match odds entry with the specified
        /// identifier was not found (false).
        /// </returns>
        public async Task<bool> DeleteMatchOddsAsync(int id)
        {
            return await DeleteEntityAsync(id);
        }
    }
}
