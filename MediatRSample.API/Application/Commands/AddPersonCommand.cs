using MediatR;

namespace MediatRSample.API.Application.Commands
{
    //Representa uma classe para o comando de Adição do sistema, deve conter apenas os
    //dados necessários para a criação de uma nova pessoa e ser usada apenas para este fim
    //seguindo as diretrizes do Mediator Pattern
    public class AddPersonCommand: IRequest<string>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
