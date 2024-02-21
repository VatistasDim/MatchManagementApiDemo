using MatchManagementApiDemo.Interfaces.Services;
using MatchManagementApiDemo.Models.DTO;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<MatchOddsDto>>> GetMatchOdds()
        {
            var matchOddsDtos = await _matchOddsService.GetMatchOddsAsync();
            return Ok(matchOddsDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatchOddsDto>> GetMatchOdds(int id)
        {
            var matchOddsDto = await _matchOddsService.GetMatchOddsAsync(id);

            if (matchOddsDto == null)
                return NotFound();

            return Ok(matchOddsDto);
        }

        [HttpPost]
        public async Task<ActionResult<MatchOddsDto>> PostMatchOdds([FromBody] MatchOddsDto matchOddsDto)
        {
            if (matchOddsDto == null)
                return BadRequest("Invalid match odds data");

            var addedMatchOddsDto = await _matchOddsService.AddMatchOddsAsync(matchOddsDto);

            return CreatedAtAction("GetMatchOdds", new { id = addedMatchOddsDto.ID }, addedMatchOddsDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatchOdds(int id, MatchOddsDto matchOddsDto)
        {
            var success = await _matchOddsService.UpdateMatchOddsAsync(id, matchOddsDto);

            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchOdds(int id)
        {
            var success = await _matchOddsService.DeleteMatchOddsAsync(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
