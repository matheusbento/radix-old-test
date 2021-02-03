using RadixTest.Domain.Commands.Event;

namespace RadixTest.Test.Fake
{
    public static class CreateSensorCommandFake
    {
        private static string Country = "brasil";
        private static string Region = "sul";
        private static string Name = "sensor01";

        public static CreateSensorCommand Create ()
        {
            return new CreateSensorCommand { Country = Country, Region = Region, Name = Name };
        }

        public static CreateSensorCommand CreateWithNameEmpty()
        {
            return new CreateSensorCommand
            {
                Country = Country,
                Region = Region
            };
        }
    }
}
