using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SOAPPractise.Model.DTO
{
    [XmlRoot("DepartmentDto")]
    public class DepartmentDto
    {
        [Required]
        [XmlElement("Id")]
        public Guid Id { get; set; }

        [Required]
        [XmlElement("DepartmentName")]
        public string DepartmentName { get; set; }
    }
}
