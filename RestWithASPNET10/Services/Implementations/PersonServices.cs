using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;

namespace RestWithASPNET10.Services.Implementations
{
    public class PersonServices : IPersonServices
    {
        private MSSQLContext _context;
        public PersonServices(MSSQLContext context)
        {
            _context = context;
        }
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
        public Person FindById(long id)
        {
            return _context.Persons.Find(id);
        }
        public Person Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }
        public Person Update(Person person)
        {
            var personBD = _context.Persons.Find(person.Id);
            if (personBD == null)
            {
                return null;
            }
            _context.Entry(personBD).CurrentValues.SetValues(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(long id)
        {
            var person = _context.Persons.Find(id);
            if (person == null)
            {
                return;
            }
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}
