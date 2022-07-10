using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working_with_events_api.Domain;
using Working_with_events_api.Repositories;

namespace Working_with_events_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpPostController : Controller
    {
        private readonly IEventRepository _productRepository;

        public HttpPostController(IEventRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("create-event")]
        public async Task<IActionResult> CreateProduct([FromBody] Event evnt)
        {
            try
            {
                await _productRepository.Insert(evnt);
                return Ok($"Объект - {evnt.Theme} добавился в БД");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-event")]
        public async Task<IActionResult> CreateProducts([FromBody] IEnumerable<Event> evnt)
        {
            try
            {
                await _productRepository.InsertSomeValues(evnt);
                return Ok($"Объекты добавились в БД");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-event-only-spiker/{spiker}/{description}")]
        public async Task<IActionResult> CreateProductOnlyName(string spiker, string description)
        {
            try
            {
                var evnt = new Event()
                {
                    Spiker = spiker,
                    Description = description,
                };

                await _productRepository.Insert(evnt);
                return Ok($"Объект - {evnt.Spiker} добавился в БД");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
