using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Merachel.Libraries
{
    public class Helper
    {
        public static string XmlSerializer<T>(T dataToSerialize)
        {
            try
            {
                // removes version
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;

                XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
                StringWriter sw = new StringWriter();
                using (XmlWriter writer = XmlWriter.Create(sw, settings))
                {
                    // removes namespace
                    var xmlns = new XmlSerializerNamespaces();
                    xmlns.Add(string.Empty, string.Empty);

                    xsSubmit.Serialize(writer, dataToSerialize, xmlns);
                    return sw.ToString(); // Your XML
                }
            }
            catch
            {
                throw;
            }
        }

        public static T XMLDeserializer<T>(string xmlText)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }
    }
}
