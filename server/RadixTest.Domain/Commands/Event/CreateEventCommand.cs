using Flunt.Notifications;
using Flunt.Validations;
using RadixTest.Domain.Commands.Contracts;
using RadixTest.Domain.Enum;
using System;

namespace RadixTest.Domain.Commands.Event
{
    public class CreateEventCommand : Notifiable, ICommand
    {
        public string Tag { get; set; }
        public String Value { get; set; }
        public Int64 Timestamp { get; set; }

        public void Validate()
        {
            AddNotifications(
              new Contract()
                  .Requires()
                  .IsNotNullOrEmpty(Tag, "Tag", "Tag can not be empty!")
                  .IsNotNull(Timestamp, "Timestamp", "Timestamp can not be empty!")
          );
        }
    }
}
