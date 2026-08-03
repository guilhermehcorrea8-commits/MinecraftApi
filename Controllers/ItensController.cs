using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_29_07_Mine.Context;
using Web_Api_29_07_Mine.DTOs;
using Web_Api_29_07_Mine.Models;

namespace Web_Api_29_07_Mine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItensController : ControllerBase
{
    private readonly MinecraftContext _context;

    public ItensController(MinecraftContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Lista todos os itens.
    /// </summary>
    /// <returns>Lista de itens cadastrados.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ItemResponseDTO>>> Get()
    {
        return Ok(await _context.Itens
            .AsNoTracking()
            .Select(i => new ItemResponseDTO
            {
                Id = i.Id,
                Nome = i.Nome,
                Tipo = i.Tipo,
                ImagemUrl = i.ImagemUrl
            })
            .ToListAsync());
    }
    /// <summary>
    /// Busca um item pelo ID.
    /// </summary>
    /// <param name="id">ID do item.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ItemResponseDTO>> Get(int id)
    {
        var item = await _context.Itens
            .AsNoTracking()
            .Where(i => i.Id == id)
            .Select(i => new ItemResponseDTO
            {
                Id = i.Id,
                Nome = i.Nome,
                Tipo = i.Tipo,
                ImagemUrl = i.ImagemUrl
            })
            .FirstOrDefaultAsync();

        if (item == null)
            return NotFound();

        return Ok(item);
    }
    /// <summary>
    /// Cadastra um novo item.
    /// </summary>
    /// <param name="dto">Dados do item.</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(ItemRequestDTO dto)
    {
        var item = new Item
        {
            Nome = dto.Nome,
            Tipo = dto.Tipo,
            ImagemUrl = dto.ImagemUrl
        };

        _context.Itens.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }
    /// <summary>
    /// Atualiza um item existente.
    /// </summary>
    /// <param name="id">ID do item.</param>
    /// <param name="dto">Novos dados.</param>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, ItemRequestDTO dto)
    {
        var item = await _context.Itens.FindAsync(id);

        if (item == null)
            return NotFound();

        item.Nome = dto.Nome;
        item.Tipo = dto.Tipo;
        item.ImagemUrl = dto.ImagemUrl;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    /// <summary>
    /// Remove um item.
    /// </summary>
    /// <param name="id">ID do item.</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Itens.FindAsync(id);

        if (item == null)
            return NotFound();

        _context.Itens.Remove(item);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}