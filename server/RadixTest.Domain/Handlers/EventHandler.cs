using Flunt.Notifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RadixTest.Domain.Commands;
using RadixTest.Domain.Commands.Contracts;
using RadixTest.Domain.Commands.Event;
using RadixTest.Domain.Entities;
using RadixTest.Domain.Enum;
using RadixTest.Domain.Handlers.Contracts;
using RadixTest.Domain.Interfaces;
using RadixTest.Domain.Services;
using System;
using System.Threading.Tasks;

namespace RadixTest.Domain.Handlers
{
    public class EventHandler :
        Notifiable,
        IHandler<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISensorRepository _sensorRepository;
        private readonly ISensorService _sensorService;
        public EventWsHandler _eventWs;
        public EventHandler(IEventRepository eventRepository, ISensorRepository sensorRepository, ISensorService sensorService, EventWsHandler eventWs)
        {
            _eventRepository = eventRepository;
            _sensorRepository = sensorRepository;
            _sensorService = sensorService;
            _eventWs = eventWs;
        }


        public async Task<ICommandResult> Handle(CreateEventCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Invalid operation!", command.Notifications);

            var sensorMock = _sensorService.GetSensorFromString(command.Tag);

            var sensor = await _sensorRepository.GetSensorByNameAndRegionAndCountry(sensorMock);

            var status = string.IsNullOrEmpty(command.Value.ToString()) ? EventStatus.Error : EventStatus.Processed;

            var @event = new Event 
            (
                sensor.Id,
                command.Value,
                command.Timestamp,
                status
            );

            await _eventRepository.AddAsync(@event);

            await _eventWs.sendEventsToAll();

            return new GenericCommandResult(true, "Event created!", new { @event.Id });
        }
    }
}
