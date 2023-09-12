using SOAPPractise.Model;
using System.Xml.Linq;

namespace SOAPPractise
{
    public class SampleService :ISampleService
    {
        public string Test(string s)
        {
            Console.WriteLine("Test Method Executed!");
            return s;
        }

        public void XmlMethod(XElement xml)
        {
            Console.WriteLine(xml.ToString());
        }

        public MyCustomModel TestCustomModel(MyCustomModel customModel)
        {
            return customModel;
        }
    }
}
