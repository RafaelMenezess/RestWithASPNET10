using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;

namespace RestWithASPNET10.Repositories.Impl
{
    public class PersonRepository(MSSQLContext context) : GenericRepository<Person>(context), IPersonRepository
    {
        public Person Disable(long id)
        {
            var person = _context.Persons.Find(id);
            if (person != null)
            {
                person.Enable = false;
                _context.SaveChanges();
            }
            return person;
        }
    }
}
