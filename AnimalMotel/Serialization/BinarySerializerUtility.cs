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
        public static void Serialize<T>(string filePath, T obj)
        {
            Stream stream = null;

            try
            {
                stream = File.Open(filePath, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, obj);
            }
            catch (Exception ex) 
            {
                throw;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
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
                filestream.Position = 0;
                i = 1;

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                i = 2;
                

                string info = binaryFormatter.ToString();
      
                obj = binaryFormatter.Deserialize(filestream);
                i = 3;

                return (T)obj;
            }
            catch (Exception ex)
            {
                
                throw;
                //throw new Exception($"Failed { i }");
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
