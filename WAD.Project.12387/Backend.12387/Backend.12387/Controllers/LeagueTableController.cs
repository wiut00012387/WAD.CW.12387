using Backend._12387.DAL;
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
    public class LeagueTableController : ControllerBase
    {
        private readonly ILeagueTableRepository _leagueTableRepository;

        public LeagueTableController(ILeagueTableRepository leagueTableRepository)
        {
            this._leagueTableRepository = leagueTableRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeagueTable>>> GetAllLeagueTables()
        {
            var leagueTables = await _leagueTableRepository.GetAllAsync(lg => lg.Club, lg => lg.League);
            return Ok(leagueTables);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeagueTable>> GetLeagueTableById(int id)
        {
            var leagueTable = await _leagueTableRepository.GetLeagueTableByIdAsync(id, lg => lg.Club, lg => lg.League);
            if (leagueTable == null)
            {
                return NotFound();
            }
            return Ok(leagueTable);
        }

        [HttpGet("{id}/league")]
        public async Task<ActionResult<IEnumerable<LeagueTable>>> GetLeagueTableByLeague(int id)
        {
            var leagueTable = await _leagueTableRepository.GetLeagueTableByLeague(id, lg => lg.Club, lg => lg.League);
            if (leagueTable == null)
            {
                return NotFound();
            }
            return Ok(leagueTable);
        }

        [HttpPost]
        public async Task<ActionResult<LeagueTable>> CreateLeagueTable(LeagueTable leagueTable)
        {
            await _leagueTableRepository.CreateAsync(leagueTable);
            await _leagueTableRepository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeagueTable(int id, LeagueTable leagueTable)
        {
            try
            {
                if (id != leagueTable.LeagueTableId)
                {
                    return BadRequest("Invalid league table Id");
                }

               
                await _leagueTableRepository.UpdateAsync(leagueTable);
                await _leagueTableRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeagueTable(int id)
        {
            try
            {
                await _leagueTableRepository.DeleteAsync(id);
                await _leagueTableRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
