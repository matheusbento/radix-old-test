using System.Collections.Generic;

namespace RadixTest.Domain.Requests
{
    public class EventRequest
    {
        public List<string> Name { get; set; }
        public List<string> Region { get; set; }
    }
}
