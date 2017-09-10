using System;
using System.Xml;
using System.Xml.Schema;

namespace tool
{
    public class XMLAnalysis
    {
        public static void Execute()
        {
            XmlSchema schema = null;
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add("urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", @"pain.001.001.03.xsd");

            foreach (XmlSchema s in schemaSet.Schemas())
            {
                schema = s;
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.Schemas.Add(schema);
            xdoc.Load(@"pain.001.001.03.xml");
            xdoc.Validate(ValidationCallBack);
        }

        private static void ValidationCallBack(object sender,
          ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Error)
            {
                Console.WriteLine("Error: " + args.Message);
            }
        }
    }
}
