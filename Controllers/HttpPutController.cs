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
    public class HttpPutController : Controller
    {
        private readonly IRepository<Event> _eventRepository;

        public HttpPutController(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpPut("edit-event")]
        public async Task<IActionResult> Edit([FromBody] Event evnt)
        {
            try
            {
                await _eventRepository.Update(evnt);
                return Ok("Объект обновился");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
