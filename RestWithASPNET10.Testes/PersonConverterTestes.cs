using FluentAssertions;
using RestWithASPNET10.Data.Converter.Impl;
using RestWithASPNET10.Data.DTO.V2;
using RestWithASPNET10.Model;

namespace RestWithASPNET10.Testes
{
    public class PersonConverterTestes
    {
        private readonly PersonConverter _converter;
        public PersonConverterTestes()
        {
            _converter = new PersonConverter();
        }

        //PersonDTO to Person converter test
        [Fact]
        public void Parse_ShouldConvertPersonDTOToPerson()
        {
            //Arrange: prepare the data, objects, and dependencies required for the test
            var dto = new PersonDTO
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
                BirthDay = new DateTime(1869, 10, 2)
            };

            var expectedPerson = new Person
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male"
            };

            // Act: execute the method or functionality under test
            var person = _converter.Parse(dto);

            // Assert: verify that the result matches the expected outcome
            person.Should().NotBeNull();
            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Gender.Should().Be(expectedPerson.Gender);
            person.Should().BeEquivalentTo(expectedPerson);
        }

        [Fact]
        public void Parse_NullPersonDTOShouldReturnNull()
        {
            PersonDTO dto = null;
            var person = _converter.Parse(dto);
            person.Should().BeNull();
        }
    }
}
