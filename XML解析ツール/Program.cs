﻿using System;
using System.Xml.Schema;

namespace XML解析ツール
{
    public class Program
    {
        public static void Main()
        {
            XmlSchema schema = null;
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add("urn:bookstore-schema", @"C:\Temp\schema1.xsd");

            foreach (XmlSchema s in schemaSet.Schemas())
            {
                schema = s;
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.Schemas.Add(schema);
            xdoc.Load(@"C:\Temp\xml1.xml");
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
