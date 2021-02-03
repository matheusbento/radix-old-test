using Microsoft.AspNetCore.Mvc;
using RadixTest.Domain.Commands;
using RadixTest.Domain.Commands.Event;
using RadixTest.Domain.Interfaces;
using RadixTest.Domain.Handlers;
using System.Threading.Tasks;
using LTS.Domain.Commands.Sensor;

namespace RadixTest.API.Controllers
{
    [ApiController]
    [Route("api/sensor")]
    public class SensorController : ControllerBase
    {
        private readonly ISensorService _sensorService;
        public SensorController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet]
        public async Task<GenericCommandResult> GetAllPaginated()
        {
            return await _sensorService.GetAll();
        }

        [HttpPost]
        public async Task<GenericCommandResult> Create([FromBody] CreateSensorCommand command, [FromServices] SensorHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [HttpDelete]
        public async Task<GenericCommandResult> Delete([FromBody] DeleteSensorCommand command, [FromServices] SensorHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }
    }
}
