using MediatR;

namespace MediatRSample.API.Application.Commands
{
    public class DeletePersonCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
