using Backend._12387.DAL;
using Backend._12387.Interfaces;
using Backend._12387.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace Backend._12387.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubController: ControllerBase
    {
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            this._clubRepository = clubRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetAllClubs()
        {
            var clubs = await _clubRepository.GetAllAsync(c => c.League, c => c.Players);
            return Ok(clubs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetClubById(int id)
        {
            var club = await _clubRepository.GetClubByIdAsync(id, c => c.League, c => c.Players);
            if (club == null)
            {
                return NotFound();
            }
            return Ok(club);
        }

        [HttpPost]
        public async Task<ActionResult<Club>> CreateClub(Club club)
        {
            await _clubRepository.CreateAsync(club);
            await _clubRepository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClub(int id, Club club)
        {
            try
            {
                if (id != club.ClubId)
                {
                    return BadRequest("Invalid club Id");
                }

                var existingClub = await _clubRepository.GetByIdAsync(id);

                if (existingClub == null)
                {
                    return NotFound($"Club with ID {id} not found");
                }

                await _clubRepository.UpdateAsync(club);
                await _clubRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClub(int id)
        {
            try
            {
                await _clubRepository.DeleteClubAsync(id);
                await _clubRepository.SaveAsync();
                return NoContent();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
