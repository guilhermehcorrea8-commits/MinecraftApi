using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_29_07_Mine.Context;

namespace Web_Api_29_07_Mine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly MinecraftContext _context;

    public DashboardController(MinecraftContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retorna estatísticas gerais da API.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDashboard()
    {
        var dashboard = new
        {
            TotalPlayers = await _context.Players.CountAsync(),
            TotalMundos = await _context.Mundos.CountAsync(),
            TotalItens = await _context.Itens.CountAsync(),
            TotalBlocos = await _context.Blocos.CountAsync(),
            TotalMobs = await _context.Mobs.CountAsync(),
            TotalBiomas = await _context.Biomas.CountAsync(),
            TotalEncantamentos = await _context.Encantamentos.CountAsync(),

            PlayersNivel50 =
                await _context.Players.CountAsync(p => p.Nivel >= 50),

            MobsHostis =
                await _context.Mobs.CountAsync(m => m.Hostil),

            MobsPacificos =
                await _context.Mobs.CountAsync(m => !m.Hostil)
        };

        return Ok(dashboard);
    }
    /// <summary>
    /// Ranking dos jogadores.
    /// </summary>
    [HttpGet("ranking")]
    public async Task<IActionResult> Ranking()
    {
        var ranking = await _context.Players
            .AsNoTracking()
            .OrderByDescending(x => x.Nivel)
            .Take(10)
            .Select(x => new
            {
                x.Nickname,
                x.Nivel
            })
            .ToListAsync();

        return Ok(ranking);
    }
    [HttpGet("mundos")]
    public async Task<IActionResult> Mundos()
    {
        var mundos = await _context.Mundos
            .Select(m => new
            {
                m.Nome,
                Jogadores = m.Players.Count
            })
            .OrderByDescending(x => x.Jogadores)
            .ToListAsync();

        return Ok(mundos);
    }
    [HttpGet("itens")]
    public async Task<IActionResult> Itens()
    {
        var itens = await _context.Itens
            .Select(i => new
            {
                i.Nome,
                Usuarios = i.Inventarios.Count
            })
            .OrderByDescending(x => x.Usuarios)
            .ToListAsync();

        return Ok(itens);
    }
}