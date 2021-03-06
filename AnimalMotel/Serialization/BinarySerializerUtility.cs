using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace AnimalMotel.Serialization
{
    /// <summary>
    /// Class used to serialize and deserialize objects
    /// using binary serialization.
    /// </summary>
    public class BinarySerializerUtility
    {
        /// <summary>
        /// Serializes an object to a given file path
        /// </summary>
        /// <typeparam name="T">Type of object to be serialized</typeparam>
        /// <param name="obj">object to be serialized</param>
        /// <param name="filePath">Path to the file that stores the data</param>
        public static void Serialize<T>(string filePath, T obj)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Create);

            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, obj);
            }
            catch (Exception ex) 
            {
                throw;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        /// <summary>
        /// Deserializes an object from a file
        /// </summary>
        /// <typeparam name="T">Type of the object to deserialize</typeparam>
        /// <param name="filePath">Path to the file to read from.</param>
        /// <returns>Object of type T</returns>
        public static T Deserialize<T>(string filePath)
        {
            FileStream filestream = null;
            object obj = null;

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file is not found. ", filePath);
            }

            try
            {
                filestream = new FileStream(filePath, FileMode.Open);
                filestream.Position = 0;
                BinaryFormatter binaryFormatter = new BinaryFormatter();
      
                obj = binaryFormatter.Deserialize(filestream);
                return (T)obj;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (filestream != null)
                {
                    filestream.Close();
                }
            }
        }
    }
}
