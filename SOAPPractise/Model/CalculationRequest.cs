using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SOAPPractise.Model
{
    [XmlRoot("CalculationRequest")]
    public class CalculationRequest
    {
        [XmlElement("operand1")]
        public int Operand1 { get; set; }
        [XmlElement("operand2")]
        public int Operand2 { get; set; }
    }
}
