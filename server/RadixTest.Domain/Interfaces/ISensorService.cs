using RadixTest.Domain.Commands;
using RadixTest.Domain.Commands.Contracts;
using RadixTest.Domain.Entities;
using RadixTest.Domain.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadixTest.Domain.Interfaces
{
    public interface ISensorService
    {
        Sensor GetSensorFromString(string tag);
        Task<Sensor> GetSensorByNameAndRegionAndCountry(string tag);
        Task<GenericCommandResult> GetAll();
    }
}
