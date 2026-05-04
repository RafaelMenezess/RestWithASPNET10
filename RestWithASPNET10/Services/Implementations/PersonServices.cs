using RestWithASPNET10.Model;

namespace RestWithASPNET10.Services.Implementations
{
    public class PersonServices : IPersonServices
    {
        public Person FindById(long id)
        {
            var person = MockPerson((int)id);
            return person;
        }

        public List<Person> FindAll()
        {
            List<Person> persons =  new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                persons.Add(MockPerson(i));
            }
            return persons;
        }

        public Person Create(Person person)
        {
            person.Id = new Random().Next(1, 1000);
            return person;
        }
        public Person Update(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            //Simulate delete
        }
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = new Random().Next(1, 1000),
                FirstName = "John" + i,
                LastName = "Doe" + i,
                Address = "123 Main Street" + i,
                Gender = "Male"
            };
        }
    }
}
