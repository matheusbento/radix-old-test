using Flunt.Notifications;
using Flunt.Validations;
using RadixTest.Domain.Commands.Contracts;
using System;

namespace LTS.Domain.Commands.Sensor
{
    public class DeleteSensorCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
              new Contract()
                  .Requires()
                  .IsNotNull(Id, "Id", "Sensor not found!")
          );
        }
    }
}

