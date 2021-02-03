using RadixTest.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadixTest.Domain.Model
{
    public class EventModel
    {
        public SensorModel Sensor { get; set; }
        public String Value { get; set; }
        public Int64 Timestamp { get; set; }
        public EventStatus Status { get; set; }
    }
}
