using System.Xml.Serialization;

namespace SOAPPractise.Model.DTO
{
    [XmlRoot("DeleteDepartmentRequestDto")]
    public class DeleteDepartmentRequestDto
    {
        [XmlElement("DepartmentName")]
        public string DepartmentName { get; set; }
    }
}
