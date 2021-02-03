using RadixTest.Domain.Commands;
using RadixTest.Domain.Commands.Contracts;
using RadixTest.Domain.Entities;
using RadixTest.Domain.Interfaces;
using RadixTest.Domain.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadixTest.Domain.Services
{
    public class SensorService: ISensorService
    {
        private readonly ISensorRepository _sensorRepository;

        public SensorService(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        public Sensor GetSensorFromString(string tag)
        {
            var data = tag.Split(".");
            return new Sensor(data[0], data[1], data[2]);
        }

        public async Task<Sensor> GetSensorByNameAndRegionAndCountry(string tag)
        {
            var sensorMock = GetSensorFromString(tag);

            var sensor = await _sensorRepository.GetSensorByNameAndRegionAndCountry(sensorMock);

            return sensor;
        }

        public async Task<GenericCommandResult> GetAll()
        {
            var data = await _sensorRepository.GetAll();

            return new GenericCommandResult(true, "Lista retornada com sucesso", data);
        }
    }
}
