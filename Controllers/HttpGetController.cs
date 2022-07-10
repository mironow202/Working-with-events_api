using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working_with_events_api.Repositories;

namespace Working_with_events_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpGetController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public HttpGetController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet("get-all-events")]
        public async Task<IActionResult> GetAllEvent()
        {
            var events = await _eventRepository.Select();
            if (events.Count() != 0) 
                return Ok(events);

            return NoContent();
        }

        [HttpGet("get-event/{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var evnt = await _eventRepository.Get(id);
            if (evnt != null)
                return Ok(evnt);

            return NoContent();
        }

        [HttpGet("get-events-by-name/{name}")]
        public async Task<IActionResult> GetEventByName(string name)
        {
            var evnt = await _eventRepository.GetBySpiker(name);
            if (evnt != null)
                return Ok(evnt);

            return NoContent();
        }
    }
}
