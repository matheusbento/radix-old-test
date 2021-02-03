using RadixTest.Domain.Commands;
using RadixTest.Domain.Requests;
using System.Threading.Tasks;

namespace RadixTest.Domain.Interfaces
{
    public interface IEventService
    {
        Task<GenericCommandResult> GetAllWithFilters(EventRequest eventRequest);

        Task<GenericCommandResult> GetCountByRegionAndSensor();
    }
}
