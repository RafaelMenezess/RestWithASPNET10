using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Data.DTO.V2;
using RestWithASPNET10.Services.Implementations;

namespace RestWithASPNET10.Controllers.V2
{
    [ApiController]
    [Route("api/[controller]/v2")]
    public class PersonController : ControllerBase
    {
        private readonly PersonServicesV2 _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(PersonServicesV2 personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Creating new person");
            var createdPerson = _personService.Create(person);
            if (createdPerson == null)
            {
                _logger.LogError("Failed to create person");
                return NotFound();
            }
            return Ok(createdPerson);
        }
    }
}
