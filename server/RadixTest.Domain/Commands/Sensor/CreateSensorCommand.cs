using Flunt.Notifications;
using Flunt.Validations;
using RadixTest.Domain.Commands.Contracts;

namespace RadixTest.Domain.Commands.Event
{
    public class CreateSensorCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }

        public void Validate()
        {
            AddNotifications(
              new Contract()
                  .Requires()
                  .IsNotNullOrEmpty(Name, "Name", "Name can not be empty!")
                  .IsNotNullOrEmpty(Country, "Country", "Country can not be empty!")
                  .IsNotNullOrEmpty(Region, "Region", "Region can not be empty!")
          );
        }
    }
}
