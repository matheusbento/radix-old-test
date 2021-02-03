using Newtonsoft.Json;
using RadixTest.Domain.Connectors;
using RadixTest.Domain.Entities;
using RadixTest.Domain.Interfaces;
using RadixTest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace RadixTest.Domain.Handlers
{
    public class EventWsHandler : WebSocketHandler
    {
        private readonly IEventRepository _eventRepository;
        public EventWsHandler(ConnectionManager webSocketConnectionManager, IEventRepository eventRepository) : base(webSocketConnectionManager)
        {
            _eventRepository = eventRepository;
        }

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);

            await sendEventsToAll();
        }

        private List<EventModel> MapperEvents(List<Event> events)
        {
            var newEvents = new List<EventModel>();
            foreach (var item in events)
            {

                newEvents.Add(new EventModel
                {
                    Value = item.Value,
                    Timestamp = item.Timestamp,
                    Status = item.Status,
                    Sensor = new SensorModel
                    {
                        Country = item.Sensor.Country,
                        Region = item.Sensor.Region,
                        Name = item.Sensor.Name
                    }
                }
                );
            }
            return newEvents;
        }

        public async Task sendEventsToAll()
        {
            var events = await _eventRepository.GetBySensor();

            var newEvents = MapperEvents(events);

            var json = JsonConvert.SerializeObject(newEvents);

            await SendMessageToAllAsync(json);
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var socketId = WebSocketConnectionManager.GetId(socket);
            var message = $"{socketId} said: {Encoding.UTF8.GetString(buffer, 0, result.Count)}";

            await SendMessageToAllAsync(message);
        }
    }
}
