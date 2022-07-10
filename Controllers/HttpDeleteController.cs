using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Working_with_events_api.Repositories;

namespace Working_with_events_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpDeleteController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public HttpDeleteController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpDelete("delete-evnt/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evnt = await _eventRepository.Get(id);
                if (evnt != null)
                {
                    await _eventRepository.Delete(evnt);
                    return Ok($"Объект - {evnt.Theme} удалился");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-event-by-name/{name}")]
        public async Task<IActionResult> DeleteByName(string name)
        {
            try
            {
                var evnt = await _eventRepository.GetBySpiker(name);
                if (evnt != null)
                {
                    await _eventRepository.Delete(evnt);
                    return Ok($"Объект - {evnt.Spiker} удалился");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
