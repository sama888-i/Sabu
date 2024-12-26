using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sabu.DTOs.Languages;
using Sabu.Exceptions;
using Sabu.Services.Abstracts;

namespace Sabu.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController(ILanguageService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {     
            await _service.CreateAsync(dto);
            return Ok();
           
        }
        [HttpPut]
        public async Task<IActionResult> Update(string code,LanguageUpdateDto dto)
        {
            await _service.UpdateAsync(code, dto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string code)
        {
            await _service.DeleteAsync(code);
            return Ok();
        }
        [HttpGet("ByCode")]
        public async Task<IActionResult> GetByCode(string code)
        {
            return Ok(await _service.GetByCodeLangAsync(code));
        }
    }
}
