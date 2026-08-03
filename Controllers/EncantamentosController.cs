using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_29_07_Mine.Context;
using Web_Api_29_07_Mine.DTOs;
using Web_Api_29_07_Mine.Models;

namespace Web_Api_29_07_Mine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EncantamentosController : ControllerBase
{
    private readonly MinecraftContext _context;

    public EncantamentosController(MinecraftContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Lista todos os encantamentos.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<EncantamentoResponseDTO>>> Get()
    {
        return Ok(await _context.Encantamentos
            .AsNoTracking()
            .Select(e => new EncantamentoResponseDTO
            {
                Id = e.Id,
                Nome = e.Nome,
                NivelMaximo = e.NivelMaximo,
                Categoria = e.Categoria,
                Descricao = e.Descricao
            })
            .ToListAsync());
    }
    /// <summary>
    /// Busca um encantamento pelo ID.
    /// </summary>
    /// <param name="id">ID do encantamento.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EncantamentoResponseDTO>> Get(int id)
    {
        var encantamento = await _context.Encantamentos
            .AsNoTracking()
            .Where(e => e.Id == id)
            .Select(e => new EncantamentoResponseDTO
            {
                Id = e.Id,
                Nome = e.Nome,
                NivelMaximo = e.NivelMaximo,
                Categoria = e.Categoria,
                Descricao = e.Descricao
            })
            .FirstOrDefaultAsync();

        if (encantamento == null)
            return NotFound();

        return Ok(encantamento);
    }

    [HttpPost]/// <summary>
              /// Cadastra um novo encantamento.
              /// </summary>
              /// <param name="dto">Dados do encantamento.</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(EncantamentoRequestDTO dto)
    {
        var encantamento = new Encantamento
        {
            Nome = dto.Nome,
            NivelMaximo = dto.NivelMaximo,
            Categoria = dto.Categoria,
            Descricao = dto.Descricao
        };

        _context.Encantamentos.Add(encantamento);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = encantamento.Id }, encantamento);
    }
    /// <summary>
    /// Atualiza um encantamento existente.
    /// </summary>
    /// <param name="id">ID do encantamento.</param>
    /// <param name="dto">Novos dados.</param>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, EncantamentoRequestDTO dto)
    {
        var encantamento = await _context.Encantamentos.FindAsync(id);

        if (encantamento == null)
            return NotFound();

        encantamento.Nome = dto.Nome;
        encantamento.NivelMaximo = dto.NivelMaximo;
        encantamento.Categoria = dto.Categoria;
        encantamento.Descricao = dto.Descricao;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    /// <summary>
    /// Remove um encantamento.
    /// </summary>
    /// <param name="id">ID do encantamento.</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var encantamento = await _context.Encantamentos.FindAsync(id);

        if (encantamento == null)
            return NotFound();

        _context.Encantamentos.Remove(encantamento);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}