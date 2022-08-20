using MediatR;
using MediatRSample.API.Application.Notifications;

namespace MediatRSample.API.Application.EventHandlers
{
    public class LogEventHandler : 
                INotificationHandler<CreatedPersonNotification>,
                INotificationHandler<UpdatedPersonNotification>,
                INotificationHandler<DeletedPersonNotification>,
                INotificationHandler<ErroNotification>
    {
        public Task Handle(CreatedPersonNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id}' - '{notification.Name}' - '{notification.Age}' - '{notification.Gender}'");
            });
        }

        public Task Handle(UpdatedPersonNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERACAO: '{notification.Id}' - '{notification.Name}' - '{notification.Age}' - '{notification.Gender}'");
            });
        }

        public Task Handle(DeletedPersonNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id}'");
            });
        }

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Exception}' \n {notification.StackTrace}");
            });
        }
    }
}
