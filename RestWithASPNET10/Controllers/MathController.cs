using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string number)
        {
            throw new NotImplementedException();
        }

        private bool IsNumeric(string firstNumber)
        {
            throw new NotImplementedException();
        }
    }
}
