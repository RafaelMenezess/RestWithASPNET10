using RestWithASPNET10.Model;

namespace RestWithASPNET10.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindByName(string firstName, string lastName);
    }
}
