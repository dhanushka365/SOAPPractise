using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SOAPPractise.Model
{
    
    public class Department
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }


    }
}
