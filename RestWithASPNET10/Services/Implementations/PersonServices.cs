using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;
using RestWithASPNET10.Repositories.Impl;

namespace RestWithASPNET10.Services.Implementations
{
    public class PersonServices : IPersonServices
    {
        private PersonRepository _repository;
        public PersonServices(MSSQLContext context)
        {
            _repository = new PersonRepository(context);
        }
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
