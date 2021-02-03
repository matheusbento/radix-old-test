using System;
using System.Collections.Generic;
using System.Text;

namespace RadixTest.Domain.Response
{
    public class EventResponse
    {
        public string Tag { get; set; }
        public int Count { get; set; }
        public string SensorName { get; set; }

        public EventResponse(string tag = "", int count = 0, string sensorName = "")
        {
            Tag = tag;
            Count = count;
            SensorName = sensorName;
        }
    }
}
