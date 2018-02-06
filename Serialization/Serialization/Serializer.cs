namespace Serialization
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public static class Serializer
    {
        public static string Serialize<T>(T iObj)
        {
            var iNameSpaces = new XmlSerializerNamespaces();
            iNameSpaces.Add("", "");

            var iSettings = new XmlWriterSettings() { OmitXmlDeclaration = true, Indent = true, IndentChars = "  " };

            var iStringBuilder = new StringBuilder();
            using (var iWriter = XmlTextWriter.Create(iStringBuilder, iSettings))
            {
                new XmlSerializer(typeof(T)).Serialize(iWriter, iObj, iNameSpaces);
            }
            return iStringBuilder.ToString();
        }

        public static T Deserialize<T>(string iString)
        {
            T Result = default(T);
            using (var iMemoryStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(iString ?? "")))
            using (var iReader = XmlTextReader.Create(iMemoryStream))
            {
                Result = (T)new XmlSerializer(typeof(T)).Deserialize(iReader);
            }
            return Result;
        }
    }
}
