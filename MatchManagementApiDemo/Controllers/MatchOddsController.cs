using MatchManagementApiDemo.Interfaces.Services;
using MatchManagementApiDemo.Models.DTO;
using MatchManagementApiDemo.Models.DTO.APIResponseDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchManagementApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchOddsController : ControllerBase
    {
        private readonly IMatchOddsService _matchOddsService;
        public MatchOddsController(IMatchOddsService matchOddsService)
        {
            _matchOddsService = matchOddsService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<MatchOddsDto>>>> GetMatchOdds()
        {
            try
            {
                var matchOddsDtos = await _matchOddsService.GetMatchOddsAsync();
                return Ok(ApiResponse<IEnumerable<MatchOddsDto>>.SuccessResponse(matchOddsDtos));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<IEnumerable<MatchOddsDto>>.ErrorResponse(ex.Message));
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<MatchOddsDto>>> GetMatchOdds(int id)
        {
            try
            {
                var matchOddsDto = await _matchOddsService.GetMatchOddsAsync(id);

                if (matchOddsDto == null)
                    return NotFound();

                return Ok(ApiResponse<MatchOddsDto>.SuccessResponse(matchOddsDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<MatchOddsDto>.ErrorResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<MatchOddsDto>>> PostMatchOdds([FromBody] MatchOddsDto matchOddsDto)
        {
            try
            {
                if (matchOddsDto == null)
                    return BadRequest(ApiResponse<MatchOddsDto>.ErrorResponse("Invalid match odds data"));

                var addedMatchOddsDto = await _matchOddsService.AddMatchOddsAsync(matchOddsDto);

                return CreatedAtAction("GetMatchOdds", new { id = addedMatchOddsDto.ID }, ApiResponse<MatchOddsDto>.SuccessResponse(addedMatchOddsDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<MatchOddsDto>.ErrorResponse(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> PutMatchOdds(int id, MatchOddsDto matchOddsDto)
        {
            try
            {
                var success = await _matchOddsService.UpdateMatchOddsAsync(id, matchOddsDto);

                if (!success)
                    return NotFound(ApiResponse<bool>.ErrorResponse($"Match odds with ID {id} not found"));

                return Ok(ApiResponse<bool>.SuccessResponse(true));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteMatchOdds(int id)
        {
            try
            {
                var success = await _matchOddsService.DeleteMatchOddsAsync(id);

                if (!success)
                    return NotFound(ApiResponse<bool>.ErrorResponse($"Match odds with ID {id} not found"));

                return Ok(ApiResponse<bool>.SuccessResponse(true));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }

    }
}
