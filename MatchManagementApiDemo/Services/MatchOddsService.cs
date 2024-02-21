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
