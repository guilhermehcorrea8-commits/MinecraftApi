using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Web_Api_29_07_Mine.Services;

namespace Web_Api_29_07_Mine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WikiController : ControllerBase
{
    private readonly WikiService _wiki;

    public WikiController(WikiService wiki)
    {
        _wiki = wiki;
    }
    /// <summary>
    /// Pesquisa um termo na Minecraft Wiki.
    /// </summary>
    /// <param name="termo">Termo pesquisado.</param>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Buscar([FromQuery] string termo)
    {
        var resultado = await _wiki.SearchAsync(termo);

        return Ok(resultado);
    }
}