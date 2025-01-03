﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("[action]")]
        public async Task<IActionResult> Start(Guid id)
        {
            
            return Ok(await _service.Start(id));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Skip(Guid id)
        {

            return Ok(await _service.Skip(id));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult>Fail(Guid id)
        {
            await _service.Fail(id);
            return Ok();       

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Success(Guid id)
        {
            await _service.Success(id);
            return Ok();

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> End(Guid id)
        {
           
            return Ok(await _service.End(id));

        }
    }
}
