using Microsoft.AspNetCore.Mvc;
using RadixTest.Domain.Commands;
using RadixTest.Domain.Commands.Event;
using RadixTest.Domain.Interfaces;
using RadixTest.Domain.Handlers;
using System.Threading.Tasks;

namespace RadixTest.API.Controllers
{
    [ApiController]
    [Route("api/event")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        [Route("count")]
        public async Task<GenericCommandResult> GetCountByRegionAndSensor()
        {
            return await _eventService.GetCountByRegionAndSensor();
        }

        [HttpPost]
        public async Task<GenericCommandResult> Create([FromBody] CreateEventCommand command, [FromServices] EventHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }
    }
}
