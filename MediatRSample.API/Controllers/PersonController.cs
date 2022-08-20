using MediatR;
using MediatRSample.API.Application.Commands;
using MediatRSample.API.Application.Models;
using MediatRSample.API.Application.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Person> _repository;

        public PersonController(IMediator mediator, IRepository<Person> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAllAsync()); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddPersonCommand command)
        {
            //o metodo Send será o responsavel por executar uma tarefa que irá chamar o Handler
            //desse comando e irá retornar a resposta do método Handle
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePersonCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePersonCommand { Id = id });
            return Ok(result);  
        }


    }
}
