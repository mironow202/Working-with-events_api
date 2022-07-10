using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Working_with_events_api.Domain;
using Working_with_events_api.Repositories;

namespace Working_with_events_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpPostController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public HttpPostController(IEventRepository productRepository)
        {
            _eventRepository = productRepository;
        }

        [HttpPost("create-event")]
        public async Task<IActionResult> CreateEvent([FromBody] Event evnt)
        {
            try
            {
                await _eventRepository.Insert(evnt);
                return Ok($"Объект - {evnt.Theme} добавился в БД");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-events")]
        public async Task<IActionResult> CreateEvents([FromBody] IEnumerable<Event> evnt)
        {
            try
            {
                await _eventRepository.InsertSomeValues(evnt);
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

                await _eventRepository.Insert(evnt);
                return Ok($"Объект - {evnt.Spiker} добавился в БД");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
