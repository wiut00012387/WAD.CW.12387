using Backend._12387.Interfaces;
using Backend._12387.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend._12387.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueRepository _leagueRepository;

        public LeagueController(ILeagueRepository leagueRepository)
        {
            this._leagueRepository = leagueRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<League>>> GetAllLeagues()
        {
            var leagues = await _leagueRepository.GetAllAsync(null);
            return Ok(leagues);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<League>> GetLeagueById(int id)
        {
            var league = await _leagueRepository.GetByIdAsync(id);
            if (league == null)
            {
                return NotFound();
            }
            return Ok(league);
        }

        [HttpPost]
        public async Task<ActionResult<League>> CreateLeague(League league)
        {
            await _leagueRepository.CreateAsync(league);
            await _leagueRepository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeague(int id, League league)
        {
            try
            {
                if (id != league.LeagueId)
                {
                    return BadRequest("Invalid league Id");
                }

                await _leagueRepository.UpdateAsync(league);
                await _leagueRepository.SaveAsync();
                return NoContent();
            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeague(int id)
        {
            try
            {
                await _leagueRepository.DeleteLeagueAsync(id);
                await _leagueRepository.SaveAsync();
                return NoContent();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
