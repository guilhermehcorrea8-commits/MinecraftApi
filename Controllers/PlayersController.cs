using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_29_07_Mine.Context;
using Web_Api_29_07_Mine.DTOs;
using Web_Api_29_07_Mine.Models;

namespace Web_Api_29_07_Mine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly MinecraftContext _context;

    public PlayersController(MinecraftContext context)
    {
        _context = context;
    }

    // GET: api/players
    /// <summary>
    /// Lista todos os jogadores cadastrados.
    /// </summary>
    /// <returns>Lista de jogadores.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PlayerResponseDTO>>> GetPlayers()
    {
        var players = await _context.Players
            .AsNoTracking()
            .Include(p => p.Mundo)
            .Select(p => new PlayerResponseDTO
            {
                Id = p.Id,
                Nickname = p.Nickname,
                Nivel = p.Nivel,
                Uuid = p.Uuid,
                SkinUrl = p.SkinUrl,
                Mundo = p.Mundo!.Nome
            })
            .ToListAsync();

        return Ok(players);
    }
    /// <summary>
    /// Busca um jogador pelo ID.
    /// </summary>
    /// <param name="id">ID do jogador.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PlayerResponseDTO>> GetPlayer(int id)
    {
        var player = await _context.Players
            .AsNoTracking()
            .Include(p => p.Mundo)
            .Where(p => p.Id == id)
            .Select(p => new PlayerResponseDTO
            {
                Id = p.Id,
                Nickname = p.Nickname,
                Nivel = p.Nivel,
                Uuid = p.Uuid,
                SkinUrl = p.SkinUrl,
                Mundo = p.Mundo!.Nome
            })
            .FirstOrDefaultAsync();

        if (player == null)
            return NotFound();

        return Ok(player);
    }
    /// <summary>
    /// Pesquisa jogadores pelo nickname.
    /// </summary>
    /// <param name="nickname">Nome do jogador.</param>
    [HttpGet("buscar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PlayerResponseDTO>>> Buscar([FromQuery] string nickname)
    {
        var players = await _context.Players
            .AsNoTracking()
            .Include(p => p.Mundo)
            .Where(p => p.Nickname.Contains(nickname))
            .Select(p => new PlayerResponseDTO
            {
                Id = p.Id,
                Nickname = p.Nickname,
                Nivel = p.Nivel,
                Uuid = p.Uuid,
                SkinUrl = p.SkinUrl,
                Mundo = p.Mundo!.Nome
            })
            .ToListAsync();

        return Ok(players);
    }
    /// <summary>
    /// Cadastra um novo jogador.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PlayerResponseDTO>> Post(PlayerRequestDTO dto)
    {
        var player = new Player
        {
            Nickname = dto.Nickname,
            Nivel = dto.Nivel,
            MundoId = dto.MundoId
        };

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPlayer),
            new { id = player.Id },
            new PlayerResponseDTO
            {
                Id = player.Id,
                Nickname = player.Nickname,
                Nivel = player.Nivel,
                Uuid = player.Uuid,
                SkinUrl = player.SkinUrl,
                Mundo = ""
            });
    }
    /// <summary>
    /// Atualiza um jogador existente.
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, PlayerRequestDTO dto)
    {
        var player = await _context.Players.FindAsync(id);

        if (player == null)
            return NotFound();

        player.Nickname = dto.Nickname;
        player.Nivel = dto.Nivel;
        player.MundoId = dto.MundoId;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    /// <summary>
    /// Remove um jogador.
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var player = await _context.Players.FindAsync(id);

        if (player == null)
            return NotFound();

        _context.Players.Remove(player);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}