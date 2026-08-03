using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_29_07_Mine.Context;
using Web_Api_29_07_Mine.DTOs;
using Web_Api_29_07_Mine.Models;

namespace Web_Api_29_07_Mine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BiomasController : ControllerBase
{
    private readonly MinecraftContext _context;

    public BiomasController(MinecraftContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Lista todos os biomas.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BiomaResponseDTO>>> Get()
    {
        return Ok(await _context.Biomas
            .AsNoTracking()
            .Select(b => new BiomaResponseDTO
            {
                Id = b.Id,
                Nome = b.Nome,
                Temperatura = b.Temperatura,
                Chove = b.Chove,
                ImagemUrl = b.ImagemUrl
            })
            .ToListAsync());
    }
    /// <summary>
    /// Busca um bioma pelo ID.
    /// </summary>
    /// <param name="id">ID do bioma.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BiomaResponseDTO>> Get(int id)
    {
        var bioma = await _context.Biomas
            .AsNoTracking()
            .Where(b => b.Id == id)
            .Select(b => new BiomaResponseDTO
            {
                Id = b.Id,
                Nome = b.Nome,
                Temperatura = b.Temperatura,
                Chove = b.Chove,
                ImagemUrl = b.ImagemUrl
            })
            .FirstOrDefaultAsync();

        if (bioma == null)
            return NotFound();

        return Ok(bioma);
    }
    /// <summary>
    /// Cadastra um novo bioma.
    /// </summary>
    /// <param name="dto">Dados do bioma.</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(BiomaRequestDTO dto)
    {
        var bioma = new Bioma
        {
            Nome = dto.Nome,
            Temperatura = dto.Temperatura,
            Chove = dto.Chove,
            ImagemUrl = dto.ImagemUrl
        };

        _context.Biomas.Add(bioma);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = bioma.Id }, bioma);
    }
    /// <summary>
    /// Atualiza um bioma existente.
    /// </summary>
    /// <param name="id">ID do bioma.</param>
    /// <param name="dto">Novos dados.</param>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, BiomaRequestDTO dto)
    {
        var bioma = await _context.Biomas.FindAsync(id);

        if (bioma == null)
            return NotFound();

        bioma.Nome = dto.Nome;
        bioma.Temperatura = dto.Temperatura;
        bioma.Chove = dto.Chove;
        bioma.ImagemUrl = dto.ImagemUrl;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    /// <summary>
    /// Remove um bioma.
    /// </summary>
    /// <param name="id">ID do bioma.</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var bioma = await _context.Biomas.FindAsync(id);

        if (bioma == null)
            return NotFound();

        _context.Biomas.Remove(bioma);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}