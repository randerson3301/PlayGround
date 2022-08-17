using MediatR;

namespace MediatRSample.API.Application.Notifications
{
    //Como as classes commands não possuem o objetivo de retornar informações, podemos criar
    //classes de notifications para serem utilizadas pelo EventHandler no momento em que o 
    //mediator emitir uma notificação.
    public class UpdatedPersonNotification : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public bool IsFinished { get; internal set; }
    }
}