using MatchManagementApiDemo.Interfaces.Services;
using MatchManagementApiDemo.Models;
using MatchManagementApiDemo.Models.DTO;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatches()
        {
            var matches = await _matchService.GetMatchesAsync();
            return Ok(matches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDto>> GetMatch(int id)
        {
            var match = await _matchService.GetMatchAsync(id);

            if (match == null)
                return NotFound();

            return Ok(match);
        }

        [HttpPost]
        public async Task<ActionResult<MatchDto>> PostMatch([FromBody] MatchDto matchDto)
        {
            if (matchDto == null)
                return BadRequest("Invalid match data");

            var addedMatch = await _matchService.AddMatchAsync(matchDto);

            return CreatedAtAction("GetMatch", new { id = addedMatch.ID }, addedMatch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(int id, [FromBody] MatchDto matchDto)
        {
            var success = await _matchService.UpdateMatchAsync(id, matchDto);

            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var success = await _matchService.DeleteMatchAsync(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
