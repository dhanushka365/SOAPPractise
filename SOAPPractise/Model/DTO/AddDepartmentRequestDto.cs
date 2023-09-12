using System.Xml.Serialization;

namespace SOAPPractise.Model.DTO
{
    [XmlRoot("AddDepartmentRequestDto")]
    public class AddDepartmentRequestDto
    {
        [XmlElement("DepartmentName")]
        public string DepartmentName { get; set; }
    }
}
