using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors; 
using YoutubeCategorizer.Core.Services;

namespace YoutubeCategorizer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors]
public class YoutubeController : ControllerBase
{
    private readonly YoutubePlaywrighService _service;

    public YoutubeController(YoutubePlaywrighService service)
    {
        _service = service;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string query)
    {
        var results = await _service.Search(query);
        return Ok(results);
    }
}