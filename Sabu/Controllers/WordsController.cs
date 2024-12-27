using Microsoft.AspNetCore.Mvc;
using Sabu.DTOs.Words;
using Sabu.Exceptions;
using Sabu.Services.Abstracts;

namespace Sabu.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class WordsController(IWordService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WordCreateDto dto)
        {  
             await _service.CreateAsync(dto);
             return Ok();

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteWord(string text)
        {         
            await _service.DeleteAsync(text);
            return Ok();
           
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdateWord(string text,WordUpdateDto dto)
        {            
            
            await _service.UpdateAsync(text, dto);
            return Ok();
                       

        }
        [HttpPost("[action]") ]
        public async Task<IActionResult> CreateMany(List<WordCreateDto> dto)
        {
            foreach(var item in dto)
            {
                await _service.CreateAsync(item);
            }
          
            return Ok();

        }
        [HttpGet("ByWord")]
        public async Task<IActionResult>GetByText(string text)
        {
            return Ok(await _service.GetWordByText (text));
        }
    }
}
