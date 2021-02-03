using Flunt.Notifications;
using LTS.Domain.Commands.Sensor;
using RadixTest.Domain.Commands;
using RadixTest.Domain.Commands.Contracts;
using RadixTest.Domain.Commands.Event;
using RadixTest.Domain.Entities;
using RadixTest.Domain.Handlers.Contracts;
using RadixTest.Domain.Interfaces;
using System.Threading.Tasks;

namespace RadixTest.Domain.Handlers
{
    public class SensorHandler :
        Notifiable,
        IHandler<CreateSensorCommand>
    {
        private readonly ISensorRepository _sensorRepository;
        public SensorHandler(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        public async Task<ICommandResult> Handle(CreateSensorCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Invalid operation!", command.Notifications);

            var sensor = new Sensor(command.Country, command.Region, command.Name);

            await _sensorRepository.AddAsync(sensor);

            return new GenericCommandResult(true, "Sensor created!", new { sensor.Id });
        }

        public async Task<ICommandResult> Handle(DeleteSensorCommand command)
        {

            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Invalid operation!", command.Notifications);

            var developerDb = await _sensorRepository.GetByIdAsync(command.Id);

            if (developerDb == null)
                return new GenericCommandResult(false, "Sensor not found!", command.Notifications);

            await _sensorRepository.DeleteAsync(command.Id);

            return new GenericCommandResult(true, "Sensor removed!", developerDb);
        }
    }
}
