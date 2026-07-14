using Mapster;
using RestWithASPNET10.Data.DTO.V1;
using RestWithASPNET10.Model;
using RestWithASPNET10.Repositories;

namespace RestWithASPNET10.Services.Implementations
{
    public class PersonServices : IPersonServices
    {
        private IRepository<Person> _repository;
        public PersonServices(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public List<PersonDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<PersonDTO>>();
        }

        public PersonDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<PersonDTO>();
        }

        public PersonDTO Create(PersonDTO person)
        {
            var entity = person.Adapt<Person>();
            entity = _repository.Create(entity);
            return entity.Adapt<PersonDTO>();
        }

        public PersonDTO Update(PersonDTO person)
        {
            var entity = person.Adapt<Person>();
            entity = _repository.Update(entity);
            return entity.Adapt<PersonDTO>();
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
