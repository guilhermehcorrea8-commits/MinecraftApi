using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_29_07_Mine.Context;
using Web_Api_29_07_Mine.DTOs;
using Web_Api_29_07_Mine.Models;

namespace Web_Api_29_07_Mine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MundosController : ControllerBase
{
    private readonly MinecraftContext _context;

    public MundosController(MinecraftContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Lista todos os mundos.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MundoResponseDTO>>> Get()
    {
        return Ok(await _context.Mundos
            .AsNoTracking()
            .Select(m => new MundoResponseDTO
            {
                Id = m.Id,
                Nome = m.Nome,
                Bioma = m.Bioma
            })
            .ToListAsync());
    }
    /// <summary>
    /// Busca um mundo pelo ID.
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MundoResponseDTO>> Get(int id)
    {
        var mundo = await _context.Mundos
            .AsNoTracking()
            .Where(m => m.Id == id)
            .Select(m => new MundoResponseDTO
            {
                Id = m.Id,
                Nome = m.Nome,
                Bioma = m.Bioma
            })
            .FirstOrDefaultAsync();

        if (mundo == null)
            return NotFound();

        return Ok(mundo);
    }
    /// <summary>
    /// Cadastra um novo mundo.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(MundoRequestDTO dto)
    {
        var mundo = new Mundo
        {
            Nome = dto.Nome,
            Bioma = dto.Bioma
        };

        _context.Mundos.Add(mundo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = mundo.Id }, mundo);
    }
    /// <summary>
    /// Atualiza um mundo.
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, MundoRequestDTO dto)
    {
        var mundo = await _context.Mundos.FindAsync(id);

        if (mundo == null)
            return NotFound();

        mundo.Nome = dto.Nome;
        mundo.Bioma = dto.Bioma;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    /// <summary>
    /// Remove um mundo.
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var mundo = await _context.Mundos.FindAsync(id);

        if (mundo == null)
            return NotFound();

        _context.Mundos.Remove(mundo);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}