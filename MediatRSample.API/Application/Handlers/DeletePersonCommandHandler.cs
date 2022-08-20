using MediatR;
using MediatRSample.API.Application.Commands;
using MediatRSample.API.Application.Models;
using MediatRSample.API.Application.Notifications;
using MediatRSample.API.Application.Repositories.Interfaces;

namespace MediatRSample.API.Application.Handlers
{
    //Essa classe irá de fato executar o comando de exclusão solicitado pelo usuário
    //utilizando o metodo Handle implementado da interface IRequestHandler
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, string>
    {
        private readonly IRepository<Person> _repository;
        private readonly IMediator _mediator;

        public DeletePersonCommandHandler(IMediator mediator, IRepository<Person> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        //O método Handle será o responsável por de fato tentar excluir uma pessoa do sistema.
        //A lógica e os passos necessários para esse fim também estarão presentes aqui.
        public async Task<string> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            //Antes de chamar efetivamente o método Delete, é necessário obter o id da pessoa 
            //a ser removida
            int personId = request.Id;

            try
            {
                await _repository.Delete(personId);

                //o mediator irá emitir uma notificação especifica para todo o sistema
                //a classe de notificação que implementa a INotificationHandler<DeletedPersonNotification>
                //será devidamente notificada e irá processar essa notificação com o método Handle
                await _mediator.Publish(new DeletedPersonNotification { Id = personId, IsFinished = true });

                return await Task.FromResult("Exclusão realizada com sucesso!");
            }
            catch (Exception ex)
            {

                await _mediator.Publish(new DeletedPersonNotification { Id = personId, IsFinished = false });
                
                //caso alguma exceção ocorra no sistema o mediator irá publicar uma notificação para o Erro
                await _mediator.Publish(new ErroNotification { Exception = ex.Message, StackTrace = ex.StackTrace });

                return await Task.FromResult("Erro ao excluir pessoa");

            }

        }
    }
}
