using System.Security.Permissions;
using System.Xml;
using System.Xml.Schema;
using DoppleApi.Models;
namespace DoppleApi
{
    //this validator is used to compare XSD schemas with the actual XML
    public class ValidatorXSD
    {

        String fileName = "C:\\Users\\hunte\\source\\repos\\DoppleApi\\DoppleApi\\StationXmlSchema.xml";
        public void validate_click(object sender, EventArgs e)
        {
            if (fileName != null && fileName.Length > 0)
            {

                ValidateXML(fileName);
            }
        }

        public void ValidateXML(String fileName)
        {

            //GenerateXmlSchema();
            //reading the XML file
            System.Xml.XmlReader xmlReader = null;
            try
            {
                // define settings that will be used to read the XML file
                XmlReaderSettings settings = new XmlReaderSettings();
                // xsd
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags |= System.Xml.Schema.XmlSchemaValidationFlags.ProcessSchemaLocation;
                settings.ValidationFlags |= System.Xml.Schema.XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandler);
                //validate the fie with the given settings
                xmlReader = XmlReader.Create(fileName, settings);

                //iterate through the XML file
                while (xmlReader.Read())
                {
                    //do nothing

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error Validationg:" + e.Message);
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
            }

        }
        public void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            Console.WriteLine("/r/n/tValidation Error:" + args.Message);
            // LblStatus.Text = "Validation failed, message:" + args.Message;
            throw new Exception("Validation failed, message:" + args.Message);

        }

    }
}

//used to overwrite XML file
    //    public void GenerateXmlSchema()
    //    {
    //        if (File.Exists(fileName))
    //        {
    //            File.SetAttributes(fileName, FileAttributes.Normal);
    //            FileIOPermission filePermission =
    //                     new FileIOPermission(FileIOPermissionAccess.AllAccess, fileName);

    //            using (FileStream fs = new FileStream(fileName, FileMode.Create))
    //            {
    //                using (XmlWriter w = XmlWriter.Create(fs))
    //                {
    //                    w.WriteStartElement("b");
    //                    w.WriteElementString("price", "19.95");
    //                    w.WriteEndElement();
    //                    w.Flush();
    //                }
    //            }
    //        }
    //    }
    //}

/*<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xmlns:xs="http://www.w3.org/2001/XMLSchema">
  < xs:element name = "StationModel" >
    < xs:complexType >
      < xs:sequence >
        < xs:element type = "xs:byte" name="StationId"/>
        <xs:element type = "xs:string" name="StatusStation"/>
      </xs:sequence >
    </ xs:complexType >
  </ xs:element >
</ xs:schema >
    */