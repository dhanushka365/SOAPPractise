using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOAPPractise.Model;

namespace SOAPPractise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpPost("calculate")]
        public ActionResult<int> Calculate([FromBody] CalculationRequest request)
        {
            try
            {
                int result = request.Operand1 + request.Operand2;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while processing the request: " + ex.Message);
            }
        }
    }
}
