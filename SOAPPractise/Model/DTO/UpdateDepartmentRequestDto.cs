using System.Xml.Serialization;

namespace SOAPPractise.Model.DTO
{
    [XmlRoot("UpdateDepartmentRequestDto")]
    public class UpdateDepartmentRequestDto
    {
        [XmlElement("DepartmentName")]
        public string DepartmentName { get; set; }
    }
}
