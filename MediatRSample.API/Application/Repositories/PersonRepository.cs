using MediatRSample.API.Application.Models;
using MediatRSample.API.Application.Repositories.Interfaces;

namespace MediatRSample.API.Application.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private Dictionary<int, Person> people = new Dictionary<int, Person>();

        public async Task Add(Person entity)
        {
            entity.Id = people.Count + 1;   
            await Task.Run(() => people.Add(entity.Id, entity));
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => people.Remove(id));
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await Task.Run(() => people.Values.ToList());
        }

        public async Task<Person> GetAsync(int id)
        {
            return await Task.Run(() => people.GetValueOrDefault(id));
        }

        public async Task Update(Person entity)
        {
            await Task.Run(() =>
            {
                people.Remove(entity.Id);
                people.Add(entity.Id, entity);
            });
        }
    }
}
