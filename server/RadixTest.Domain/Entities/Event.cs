using RadixTest.Domain.Base;
using RadixTest.Domain.Enum;
using System;

namespace RadixTest.Domain.Entities
{
    public class Event : EntityBase
    {
        public Guid SensorId { get; set; }
        public Sensor Sensor { get; protected set; }
        public String Value { get; protected set; }
        public Int64 Timestamp { get; protected set; }
        public EventStatus Status { get; set; }

        protected Event() { }

        public Event(Guid sensorId, String value, Int64 timestamp, EventStatus status)
        {
            SensorId = sensorId;
            Value = value;
            Timestamp = timestamp;
            Status = status;
        }
    }
}
