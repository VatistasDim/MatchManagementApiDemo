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
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<MatchDto>>> GetMatches()
        {
            try
            {
                var matches = await _matchService.GetMatchesAsync();
                return Ok(ApiResponse<IEnumerable<MatchDto>>.SuccessResponse(matches));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<IEnumerable<MatchDto>>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<MatchDto>>> GetMatch(int id)
        {
            try
            {
                var match = await _matchService.GetMatchAsync(id);

                if (match == null)
                    return NotFound(ApiResponse<MatchDto>.ErrorResponse("Match not found"));

                return Ok(ApiResponse<MatchDto>.SuccessResponse(match));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<MatchDto>.ErrorResponse(ex.Message));
            }
        }


        [HttpPost]
        public async Task<ActionResult<ApiResponse<MatchDto>>> PostMatch([FromBody] MatchDto matchDto)
        {
            try
            {
                if (matchDto == null)
                    return BadRequest(ApiResponse<MatchDto>.ErrorResponse("Invalid match data"));

                var addedMatch = await _matchService.AddMatchAsync(matchDto);

                return CreatedAtAction("GetMatch", new { id = addedMatch.ID }, ApiResponse<MatchDto>.SuccessResponse(addedMatch));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<MatchDto>.ErrorResponse(ex.Message));
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> PutMatch(int id, [FromBody] MatchDto matchDto)
        {
            try
            {
                var success = await _matchService.UpdateMatchAsync(id, matchDto);

                if (!success)
                    return NotFound(ApiResponse<object>.ErrorResponse($"Match with ID {id} not found"));

                return Ok(ApiResponse<bool>.SuccessResponse(true));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteMatch(int id)
        {
            try
            {
                var success = await _matchService.DeleteMatchAsync(id);

                if (!success)
                    return NotFound(ApiResponse<object>.ErrorResponse($"Match with ID {id} not found"));

                return Ok(ApiResponse<bool>.SuccessResponse(true));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
        }

    }
}
