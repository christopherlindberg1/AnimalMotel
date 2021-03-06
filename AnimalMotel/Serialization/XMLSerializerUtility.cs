using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Xml.Serialization;

namespace AnimalMotel.Serialization
{
    public class XMLSerializerUtility
    {
        public static void Serialize<T>(string filePath, T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                try
                {
                    serializer.Serialize(streamWriter, obj);
                }
                // Catch more specific exception than this
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static T Deserialize<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                try
                {
                    return (T)serializer.Deserialize(streamReader);
                }
                // Catch more specific exception than this
                catch (Exception ex)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
