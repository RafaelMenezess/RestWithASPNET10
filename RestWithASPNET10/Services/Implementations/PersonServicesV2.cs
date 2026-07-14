using RestWithASPNET10.Data.Converter.Impl;
using RestWithASPNET10.Data.DTO.V2;
using RestWithASPNET10.Model;
using RestWithASPNET10.Repositories;

namespace RestWithASPNET10.Services.Implementations
{
    public class PersonServicesV2
    {
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;
        public PersonServicesV2(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonDTO Create(PersonDTO person)
        {
            var personModel = _converter.Parse(person);
            return _converter.Parse(_repository.Create(personModel));
        }
    }
}
