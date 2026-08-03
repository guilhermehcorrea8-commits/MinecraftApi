using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Web_Api_29_07_Mine.Services;

namespace Web_Api_29_07_Mine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
    private readonly MojangService _mojang;
    private readonly SkinService _skin;

    public ProfilesController(MojangService mojang, SkinService skin)
    {
        _mojang = mojang;
        _skin = skin;
    }
    /// <summary>
    /// Consulta um jogador na Mojang API.
    /// </summary>
    /// <param name="username">Nickname do jogador.</param>
    [HttpGet("{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string username)
    {
        var player = await _mojang.GetPlayerAsync(username);

        if (player == null)
            return NotFound();

        return Ok(new
        {
            player.Name,
            UUID = player.Id,
            Avatar = _skin.GetAvatar(player.Id),
            Skin = _skin.GetSkin(player.Id)
        });
    }
}