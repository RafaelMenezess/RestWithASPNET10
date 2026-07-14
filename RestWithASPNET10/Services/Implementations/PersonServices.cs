using RestWithASPNET10.Data.Converter.Impl;
using RestWithASPNET10.Data.DTO;
using RestWithASPNET10.Model;
using RestWithASPNET10.Repositories;

namespace RestWithASPNET10.Services.Implementations
{
    public class PersonServices : IPersonServices
    {
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;
        public PersonServices(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public List<PersonDTO> FindAll()
        {
            return _repository.FindAll().Select(item => _converter.Parse(item)).ToList();
        }
        public PersonDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        public PersonDTO Create(PersonDTO person)
        {
            var personModel = _converter.Parse(person);
            return _converter.Parse(_repository.Create(personModel));
        }
        public PersonDTO Update(PersonDTO person)
        {
            var personModel = _converter.Parse(person);
            return _converter.Parse(_repository.Update(personModel));
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
