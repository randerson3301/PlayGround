using MediatR;
using MediatRSample.API.Application.Commands;
using MediatRSample.API.Application.Models;
using MediatRSample.API.Application.Notifications;
using MediatRSample.API.Application.Repositories.Interfaces;

namespace MediatRSample.API.Application.Handlers
{
    //Essa classe irá de fato executar o comando de adição solicitado pelo usuário
    //utilizando o metodo Handle implementado da interface IRequestHandler
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Person> _repository;

        public AddPersonCommandHandler(IMediator mediator, IRepository<Person> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        //O método Handle será o responsável por de fato tentar inserir uma nova pessoa no sistema.
        //A lógica e os passos necessários para esse fim também estarão presentes aqui.       
        public async Task<string> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            //Antes de chamar efetivamente o método Add, o Handler irá 'converter' o parametro request
            // que é do tipo AddPersonCommand em uma entidade Person convencional
            var person = new Person { Name = request.Name, Age = request.Age, Gender = request.Gender };

            //inicia a tentativa de inserção da nova pessoa
            try
            {
                await _repository.Add(person);

                //o mediator irá emitir uma notificação especifica para todo o sistema
                //a classe de notificação que implementa a INotificationHandler<CreatedPersonNotification>
                //será devidamente notificada e irá processar essa notificação com o método Handle
                await _mediator.Publish(new CreatedPersonNotification { Id = person.Id, Name = person.Name, Age = person.Age, Gender = person.Gender });

                return await Task.FromResult("Pessoa criada com sucesso!!");
            } catch(Exception ex)
            {
                await _mediator.Publish(new CreatedPersonNotification { Id = person.Id, Name = person.Name, Age = person.Age, Gender = person.Gender });

                //caso alguma exceção ocorra no sistema o mediator irá publicar uma notificação para o Erro
                await _mediator.Publish(new ErroNotification { Exception = ex.Message, StackTrace = ex.StackTrace });
                
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }
        }
    }
}
