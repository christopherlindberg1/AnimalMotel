using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using AnimalMotel.Animals.Species;

namespace AnimalMotel.Serialization
{
    /// <summary>
    ///   Class used to serialize and deserialize objects
    ///   using binary serialization.
    /// </summary>
    public class BinarySerializerUtility
    {
        /// <summary>
        ///   Serializes and object to a given file path
        /// </summary>
        /// <typeparam name="T">Type of object to be serialized</typeparam>
        /// <param name="obj">object to be serialized</param>
        /// <param name="filePath">Path to the file that stores the data</param>
        /// <returns></returns>
        public static bool Serialize<T>(string filePath, T obj)
        {
            bool serializationOK = false;

            FileStream filestream = null;

            try
            {
                filestream = new FileStream(filePath, FileMode.OpenOrCreate);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(filestream, obj);
            }
            catch 
            {
                serializationOK = false;
            }
            finally
            {
                filestream.Close();
            }

            return serializationOK;
        }


        public static T Deserialize<T>(string filePath)
        {
            FileStream filestream = null;
            object obj = null;

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file is not found. ", filePath);
            }

            int i = 0;

            try
            {
                
                filestream = new FileStream(filePath, FileMode.Open);
                i = 1;

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                i = 2;

                string info = binaryFormatter.ToString();
      
                obj = binaryFormatter.Deserialize(filestream);
                i = 3;

                return (T)obj;
            }
            catch
            {
                throw new Exception($"Failed { i }");
            }
            finally
            {
                filestream.Close();
            }
        }
    }
}
