using FluentAssertions;
using NSubstitute;
using RadixTest.Domain.Commands;
using RadixTest.Domain.Entities;
using RadixTest.Domain.Handlers;
using RadixTest.Domain.Interfaces;
using RadixTest.Test.Fake;
using System.Threading.Tasks;
using Xunit;

namespace RadixTest.Test.Unit
{
    public class CreateSensorHandleTest
    {
        private readonly ISensorRepository _sensorRepository;
        public SensorHandler _sensorHandle;
        public CreateSensorHandleTest()
        {
            _sensorRepository = Substitute.For<ISensorRepository>();
            _sensorHandle = new SensorHandler(_sensorRepository);
        }

        [Fact]
        public async Task Should_returned_valid_command_when_everything_is_ok()
        {
            var command = CreateSensorCommandFake.Create();

            var result = (GenericCommandResult) await _sensorHandle.Handle(command);
            result.Message.Should().Be("Sensor created!");
        }

        [Fact]
        public async Task Should_returned_valid_command_when_name_is_empty()
        {
            var command = CreateSensorCommandFake.CreateWithNameEmpty();

            var result = (GenericCommandResult) await _sensorHandle.Handle(command);
            result.Message.Should().NotBe("Sensor created!");
        }
    }
}
