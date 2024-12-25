using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sabu.DTOs.Games;
using Sabu.Services.Abstracts;

namespace Sabu.Controllers
{
    [ApiController]
    [Route ("/api/[controller]")]
    public class GamesController(IGameService _service,IMemoryCache _cache):ControllerBase 
    {
        [HttpPost]
        public async Task<IActionResult> Create(GameCreateDto dto) 
        {
            return Ok(await _service.CreateAsync(dto));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult>Get(string key)
        {
            return Ok(_cache.Get(key));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult>Set(string key,string value)
        {
            _cache.Set<string>(key, value, DateTime.Now.AddSeconds(20));
            return Ok();
        }

    }
}
