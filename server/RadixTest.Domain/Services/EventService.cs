using RadixTest.Domain.Commands;
using RadixTest.Domain.Interfaces;
using RadixTest.Domain.Requests;
using RadixTest.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixTest.Domain.Services
{
    public class EventService: IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISensorRepository _sensorRepository;

        public EventService(IEventRepository eventRepository, ISensorRepository sensorRepository)
        {
            _eventRepository = eventRepository;
            _sensorRepository = sensorRepository;
        }

        public async Task<GenericCommandResult> GetCountByRegionAndSensor()
        {
            string country = "", region = "";

            var data = await _sensorRepository.GetWithEvents();

            int total = 0;

            var events = new List<EventResponse>();

            var eventResponseAux = new EventResponse();

            foreach (var item in data)
            {
                if(item.Region != region || item.Country != country)
                {
                    if(total != 0)
                    {
                        eventResponseAux  = new EventResponse (
                            String.Concat(country,".",region),
                            total
                        );
                        events.Add(eventResponseAux);
                        total = 0;
                    }
                    country = item.Country;
                    region = item.Region;
                }
                
                if (item.Region == region && item.Country == country)
                {
                    total += item.Events.Count();
                }
            }

            eventResponseAux = new EventResponse(String.Concat(country, ".", region),total);
            events.Add(eventResponseAux);

            var countIndividualy = data.GroupBy(x => new { x.Country, x.Region, x.Name }).Select(y => y.First());

            foreach (var item in countIndividualy)
            {
                eventResponseAux = new EventResponse(
                            String.Concat(item.Country, ".", item.Region ),
                            item.Events.Count(),
                            item.Name
                        );
                events.Add(eventResponseAux);
            }
     

            if (events == null)
                return new GenericCommandResult(false, "Result not found");

            return new GenericCommandResult(true, "Result found", events.OrderBy(x => x.Tag));
        }

        public async Task<GenericCommandResult> GetAllWithFilters(EventRequest eventRequest)
        {
            var data = await _eventRepository.GetAllWithFilters(eventRequest);

            if (data == null)
                return new GenericCommandResult(false, "Result not found");

            return new GenericCommandResult(true, "Result found", data);
        }
    }
}
