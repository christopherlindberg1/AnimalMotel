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
    ///   AppSettings class that can be used to create objects
    ///   that store application settings in RAM and make use of them
    ///   in the application.
    /// </summary>
    [Serializable()]
    public class AppSettings : ISerializable
    {
        private int _lastGeneratedId;
        private string _lastUsedFilePathForAnimals;
        private string _lastUsedFilePathForRecipes;





        /**
         * 
         * ===================  Properties  ===================
         * 
         */

        private int LastGeneratedId
        {
            get => _lastGeneratedId;

            set => _lastGeneratedId = value;
        }

        public string LastUsedFilePathForAnimals
        {
            get => _lastUsedFilePathForAnimals;

            set => _lastUsedFilePathForAnimals = value ??
                throw new ArgumentNullException(
                    "LastUsedFilePathForAnimals cannot be null",
                    "LastUsedFilePathForAnimals");
        }

        public string LastUsedFilePathForRecipes
        {
            get => _lastUsedFilePathForRecipes;

            set => _lastUsedFilePathForRecipes = value ??
                throw new ArgumentNullException(
                    "LastUsedFilePathForRecipes cannot be null",
                    "LastUsedFilePathForRecipes");
        }






        /**
         * 
         * ===================  Methods  ===================
         * 
         */

        public AppSettings()
        {
            LastUsedFilePathForAnimals = null;
            LastUsedFilePathForRecipes = null;
        }

        /// <summary>
        /// Serializes the app settings.
        /// </summary>
        public static void SaveSettingsToStorage(AppSettings appSettings)
        {
            try
            {
                XMLSerializerUtility.Serialize<AppSettings>(FilePaths.AppSettingsFilePath, appSettings);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Deserializes the app settings.
        /// </summary>
        public static AppSettings GetSettingsFromStorage()
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
        /// Creates a deep copy of an AppSettings object.
        /// </summary>
        /// <param name="appSettings">AppSettings object to copy</param>
        //public AppSettings(AppSettings appSettings)
        //{
        //    throw new NotImplementedException();
        //}

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
            LastUsedFilePathForAnimals = (string)info.GetValue("LastUsedFilePathForAnimals", typeof(string));
            LastUsedFilePathForRecipes = (string)info.GetValue("LastUsedFilePathForRecipes", typeof(string));
        }
    }
}
