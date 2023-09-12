using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOAPPractise.Model;
using System.Text;

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
                // Perform the calculation based on the request
                int result = request.Operand1 + request.Operand2;

                // Create a SOAP response
                string soapResponse = GenerateSoapResponse(result);

                // Set the content type to "text/xml" for SOAP
                Response.ContentType = "text/xml";

                // Return the SOAP response
                return Content(soapResponse, "text/xml");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during processing
                return BadRequest("An error occurred while processing the request: " + ex.Message);
            }
        }

        private string GenerateSoapResponse(int result)
        {
            // Create a StringBuilder to build the SOAP response
            StringBuilder soapResponse = new StringBuilder();

            // Append the SOAP envelope, header, and body
            soapResponse.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            soapResponse.AppendLine("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">");
            soapResponse.AppendLine("<soap:Header/>");
            soapResponse.AppendLine("<soap:Body>");
            soapResponse.AppendLine($"<CalculateResponse xmlns=\"http://tempuri.org/\">");
            soapResponse.AppendLine($"<CalculateResult>{result}</CalculateResult>");
            soapResponse.AppendLine("</CalculateResponse>");
            soapResponse.AppendLine("</soap:Body>");
            soapResponse.AppendLine("</soap:Envelope>");

            return soapResponse.ToString();
        }
    
    }
}
