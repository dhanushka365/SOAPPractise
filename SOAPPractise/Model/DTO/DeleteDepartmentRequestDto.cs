﻿using System.Xml.Serialization;

namespace SOAPPractise.Model.DTO
{
    [XmlRoot("DeleteDepartmentRequestDto")]
    public class DeleteDepartmentRequestDto
    {
        [XmlElement("Id")]
        public string Id { get; set; }
    }
}
