using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_Practise.Data;
using SOAPPractise.Model.DTO;
using SOAPPractise.Model.Repositories;
using SOAPPractise.Model;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace SOAPPractise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ERPContext _dbContext;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

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
        public DepartmentController(ERPContext dbContext, IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    // Use Entity Framework Core to retrieve departments from the database
        //    var departments = await _dbContext.Departments.ToListAsync();

        //    // Use the department repository to retrieve additional department data
        //    var departmentDomainModels = await _departmentRepository.GetAllAsync();

        //    // Map the department data to DTOs using AutoMapper
        //    var departmentDtos = _mapper.Map<List<DepartmentDto>>(departmentDomainModels);

        //    // Combine the data from both sources if needed

        //    // Return the result as an OK response
        //    return Ok(departmentDtos);
        //}

        [HttpGet]
        public async Task<IActionResult> GetById([FromBody] DeleteDepartmentRequestDto deleteDepartmentRequestDto)
        {
            try
            {
                // Use Entity Framework Core to retrieve a department by its ID
                var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.Id ==  Guid.Parse(" deleteDepartmentRequestDto.id"));

                if (department == null)
                {
                    return NotFound(); // Department not found
                }
                // Create a SOAP envelope
                var soapEnvelope = new
                {
                    Body = new
                    {
                        Department = department
                    }
                };
                // Serialize the SOAP envelope to XML
                var xmlSerializer = new XmlSerializer(typeof(object));
                var stringWriter = new StringWriter();
                using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { OmitXmlDeclaration = false }))
                {
                    xmlSerializer.Serialize(xmlWriter, soapEnvelope);
                }

                string soapResponse = stringWriter.ToString();

                return Ok(soapResponse); // Department found

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddDepartmentRequestDto addDepartmentRequestDto)
        {

            //Map DTO to domain model
            var departmentDomainModel = _mapper.Map<Department>(addDepartmentRequestDto);

            //use Domain model to create difficulty 
            await _departmentRepository.CreateAsync(departmentDomainModel);

            //Map domain model into DTO
            return Ok(_mapper.Map<DepartmentDto>(departmentDomainModel));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDepartmentRequestDto updateDepartmentRequestDto)
        {
            // Check if a department with the given ID exists
            var existingDepartment = await _departmentRepository.GetByIdAsync(id);
            if (existingDepartment == null)
            {
                return NotFound(); // Department not found
            }

            // Map the DTO with updated data to the existing domain model
            _mapper.Map(updateDepartmentRequestDto, existingDepartment);

            // Use the repository to update the department
            var updatedDepartment = await _departmentRepository.UpdateAsync(existingDepartment);

            // Map the updated department to a DTO
            var updatedDepartmentDto = _mapper.Map<DepartmentDto>(updatedDepartment);

            return Ok(updatedDepartmentDto);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDepartment([FromBody] DeleteDepartmentRequestDto deleteDepartmentRequestDto)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Received GUID: {deleteDepartmentRequestDto.Id}");
                var department = await _departmentRepository.DeleteAsync(Guid.Parse(deleteDepartmentRequestDto.Id));

                if (department == null)
                {
                    return NotFound(); // Department not found
                }

                return Ok("Department Deleted Sucessfully"); // Department deleted successfully
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
