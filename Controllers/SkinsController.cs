using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Api_29_07_Mine.Services;

namespace Web_Api_29_07_Mine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkinController : ControllerBase
    {
        private readonly MojangService _mojangService;
        private readonly SkinService _skinService;

        public SkinController(MojangService mojangService, SkinService skinService)
        {
            _mojangService = mojangService;
            _skinService = skinService;
        }
        /// <summary>
        /// Retorna a skin, avatar e UUID de um jogador.
        /// </summary>
        /// <param name="username">Nickname do jogador.</param>
        [HttpGet("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSkin(string username)
        {
            var player = await _mojangService.GetPlayerAsync(username);

            if (player == null)
                return NotFound("Jogador não encontrado.");

            return Ok(new
            {
                Nome = player.Name,
                UUID = player.Id,
                Avatar = _skinService.GetAvatar(player.Id),
                Skin = _skinService.GetSkin(player.Id)
            });
        }
    }
}