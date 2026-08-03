using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_29_07_Mine.Context;
using Web_Api_29_07_Mine.DTOs;
using Web_Api_29_07_Mine.Models;

namespace Web_Api_29_07_Mine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MobsController : ControllerBase
{
    private readonly MinecraftContext _context;

    public MobsController(MinecraftContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Lista todos os mobs.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MobResponseDTO>>> Get()
    {
        return Ok(await _context.Mobs
            .AsNoTracking()
            .Select(m => new MobResponseDTO
            {
                Id = m.Id,
                Nome = m.Nome,
                Hostil = m.Hostil,
                Vida = m.Vida,
                Drop = m.Drop,
                Bioma = m.Bioma,
                ImagemUrl = m.ImagemUrl
            })
            .ToListAsync());
    }
    /// <summary>
    /// Busca um mob pelo ID.
    /// </summary>
    /// <param name="id">ID do mob.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MobResponseDTO>> Get(int id)
    {
        var mob = await _context.Mobs
            .AsNoTracking()
            .Where(m => m.Id == id)
            .Select(m => new MobResponseDTO
            {
                Id = m.Id,
                Nome = m.Nome,
                Hostil = m.Hostil,
                Vida = m.Vida,
                Drop = m.Drop,
                Bioma = m.Bioma,
                ImagemUrl = m.ImagemUrl
            })
            .FirstOrDefaultAsync();

        if (mob == null)
            return NotFound();

        return Ok(mob);
    }
    /// <summary>
    /// Cadastra um novo mob.
    /// </summary>
    /// <param name="dto">Dados do mob.</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(MobRequestDTO dto)
    {
        var mob = new Mob
        {
            Nome = dto.Nome,
            Hostil = dto.Hostil,
            Vida = dto.Vida,
            Drop = dto.Drop,
            Bioma = dto.Bioma,
            ImagemUrl = dto.ImagemUrl
        };

        _context.Mobs.Add(mob);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = mob.Id }, mob);
    }
    /// <summary>
    /// Atualiza um mob existente.
    /// </summary>
    /// <param name="id">ID do mob.</param>
    /// <param name="dto">Novos dados.</param>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, MobRequestDTO dto)
    {
        var mob = await _context.Mobs.FindAsync(id);

        if (mob == null)
            return NotFound();

        mob.Nome = dto.Nome;
        mob.Hostil = dto.Hostil;
        mob.Vida = dto.Vida;
        mob.Drop = dto.Drop;
        mob.Bioma = dto.Bioma;
        mob.ImagemUrl = dto.ImagemUrl;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    /// <summary>
    /// Remove um mob.
    /// </summary>
    /// <param name="id">ID do mob.</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var mob = await _context.Mobs.FindAsync(id);

        if (mob == null)
            return NotFound();

        _context.Mobs.Remove(mob);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}