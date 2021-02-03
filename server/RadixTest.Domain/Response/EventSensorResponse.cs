using RadixTest.Domain.Entities;
using RadixTest.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadixTest.Domain.Response
{
    public class EventSensorResponse
    {
        public Sensor Sensor { get;  }
        public String Value { get; }
        public Int64 Timestamp { get; }
        public EventStatus Status { get; }
        public EventSensorResponse(Sensor sensor, String value, Int64 timestamp, EventStatus status)
        {
            Sensor = sensor;
            Value = value;
            Timestamp = timestamp;
            Status = status;
        }
    }
}
