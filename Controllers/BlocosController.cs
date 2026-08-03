using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_29_07_Mine.Context;
using Web_Api_29_07_Mine.DTOs;
using Web_Api_29_07_Mine.Models;

namespace Web_Api_29_07_Mine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlocosController : ControllerBase
{
    private readonly MinecraftContext _context;

    public BlocosController(MinecraftContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Lista todos os blocos.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BlocoResponseDTO>>> Get() =>
            Ok(await _context.Blocos.AsNoTracking().Select(b => new BlocoResponseDTO
            {
                Id = b.Id,
                Nome = b.Nome,
                Tipo = b.Tipo,
                Resistencia = b.Resistencia,
                Empilhavel = b.Empilhavel,
                ImagemUrl = b.ImagemUrl
            }).ToListAsync());
    /// <summary>
    /// Busca um bloco pelo ID.
    /// </summary>
    /// <param name="id">ID do bloco.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BlocoResponseDTO>> Get(int id)
    {
        var bloco = await _context.Blocos.AsNoTracking()
            .Where(b => b.Id == id)
            .Select(b => new BlocoResponseDTO
            {
                Id = b.Id,
                Nome = b.Nome,
                Tipo = b.Tipo,
                Resistencia = b.Resistencia,
                Empilhavel = b.Empilhavel,
                ImagemUrl = b.ImagemUrl
            }).FirstOrDefaultAsync();

        if (bloco == null) return NotFound();

        return Ok(bloco);
    }
    /// <summary>
    /// Cadastra um novo bloco.
    /// </summary>
    /// <param name="dto">Dados do bloco.</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(BlocoRequestDTO dto)
    {
        var bloco = new Bloco
        {
            Nome = dto.Nome,
            Tipo = dto.Tipo,
            Resistencia = dto.Resistencia,
            Empilhavel = dto.Empilhavel,
            ImagemUrl = dto.ImagemUrl
        };

        _context.Blocos.Add(bloco);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = bloco.Id }, bloco);
    }
    /// <summary>
    /// Atualiza um bloco existente.
    /// </summary>
    /// <param name="id">ID do bloco.</param>
    /// <param name="dto">Novos dados.</param>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, BlocoRequestDTO dto)
    {
        var bloco = await _context.Blocos.FindAsync(id);

        if (bloco == null) return NotFound();

        bloco.Nome = dto.Nome;
        bloco.Tipo = dto.Tipo;
        bloco.Resistencia = dto.Resistencia;
        bloco.Empilhavel = dto.Empilhavel;
        bloco.ImagemUrl = dto.ImagemUrl;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    /// <summary>
    /// Remove um bloco.
    /// </summary>
    /// <param name="id">ID do bloco.</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var bloco = await _context.Blocos.FindAsync(id);

        if (bloco == null) return NotFound();

        _context.Blocos.Remove(bloco);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}