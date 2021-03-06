using AnimalMotel.Serialization;
using AnimalMotel.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    /// <summary>
    /// AppSettings class that can be used to create objects
    /// that store application settings in RAM and make use of them
    /// in the application.
    /// </summary>
    [Serializable()]
    public class AppSettings : ISerializable
    {
        private int _lastGeneratedId;




        /**
         * 
         * ===================  Properties  ===================
         * 
         */

        public int LastGeneratedId
        {
            get => _lastGeneratedId;

            set => _lastGeneratedId = value;
        }




        /**
         * 
         * ===================  Methods  ===================
         * 
         */

        public AppSettings()
        {
        }

        /// <summary>
        /// Serializes the app settings.
        /// </summary>
        public void SaveSettingsToStorage()
        {
            try
            {
                XMLSerializerUtility.Serialize<AppSettings>(FilePaths.AppSettingsFilePath, this);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Deserializes the app settings.
        /// </summary>
        public AppSettings GetSettingsFromStorage()
        {
            try
            {
                return XMLSerializerUtility.Deserialize<AppSettings>(FilePaths.AppSettingsFilePath);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method used for deserializing AppSettings objects.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LastGeneratedId", LastGeneratedId);
        }

        /// <summary>
        /// Constructor used for deserializing AppSettings objects
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public AppSettings(SerializationInfo info, StreamingContext context)
        {
            LastGeneratedId = (int)info.GetValue("LastGeneratedId", typeof(int));
        }
    }
}
