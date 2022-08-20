using MediatR;

namespace MediatRSample.API.Application.Commands
{
    public class UpdatePersonCommand: IRequest<string>
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
