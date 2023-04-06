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
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            this._playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetAllPlayers() 
        {
            var players = await _playerRepository.GetAllAsync(p => p.Club);
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayerById(int id)
        {
            var player = await _playerRepository.GetPlayerByIdAsync(id, p => p.Club);
            if(player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(Player player)
        {
            await _playerRepository.CreateAsync(player);
            await _playerRepository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlayer(int id, Player player)
        {
            try
            {
                if (id != player.PlayerId)
                {
                    return BadRequest("Invalid player Id");
                }

               

                await _playerRepository.UpdateAsync(player);
                await _playerRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlayer(int id) 
        {
            try
            {
                await _playerRepository.DeleteAsync(id);
                await _playerRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    } 
}
