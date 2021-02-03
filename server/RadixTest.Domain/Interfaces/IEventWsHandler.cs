using System.Threading.Tasks;

namespace RadixTest.Domain.Interfaces
{
    public interface IEventWsHandler
    {
        Task sendEventsToAll();
    }
}
