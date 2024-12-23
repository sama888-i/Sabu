﻿using Microsoft.AspNetCore.Mvc;
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
            try
            {
                await _service.CreateAsync(dto);
                return Ok();

            }
            catch(Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        StatusCode = bEx.StatusCode,
                        Message = bEx.ErrorMessage

                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        ex.Message

                    });
                }

            }

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteWord(string text)
        {
            try
            {
                await _service.DeleteAsync(text);
                return Ok();

            }
            catch (Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        StatusCode = bEx.StatusCode,
                        Message = bEx.ErrorMessage

                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        ex.Message

                    });
                }

            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateWord(string text,WordUpdateDto dto)
        {
            try
            {
                await _service.UpdateAsync(text, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        StatusCode = bEx.StatusCode,
                        Message = bEx.ErrorMessage

                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        ex.Message

                    });
                }

            }

        }
    }
}
