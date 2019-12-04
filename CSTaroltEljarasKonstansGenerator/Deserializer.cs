using d7p4n4Namespace.Final.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CSTaroltEljarasKonstansGenerator
{
    public class Deserializer
    {
        public TaroltEljaras deser(string xml)
        {
            TaroltEljaras result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(TaroltEljaras));
            using (TextReader reader = new StringReader(xml))
            {
                result = (TaroltEljaras)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}