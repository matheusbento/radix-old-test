using System;
using System.Collections.Generic;
using System.Text;
using RadixTest.Domain.Base;

namespace RadixTest.Domain.Entities
{
    public class Sensor : EntityBase
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public ICollection<Event> Events { get; protected set; }
        protected Sensor() { }
        public Sensor(string country, string region, string name)
        {
            Name = name;
            Country = country;
            Region = region;
        }
    }
}
