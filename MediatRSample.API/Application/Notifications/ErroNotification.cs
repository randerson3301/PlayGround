using MediatR;

namespace MediatRSample.API.Application.Notifications
{
    //essa classe notification tem o objetivo de mapear informações de erro caso algum método Handle
    //caia na exception
    public class ErroNotification : INotification
    {
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}