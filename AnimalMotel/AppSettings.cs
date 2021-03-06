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
        private string _lastUsedFilePathForAnimals;
        private string _lastUsedFilePathForRecipes;





        /**
         * 
         * ===================  Properties  ===================
         * 
         */

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
        /// Creates a deep copy of an AppSettings object.
        /// </summary>
        /// <param name="appSettings">AppSettings object to copy</param>
        public AppSettings(AppSettings appSettings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method used for deserializing AppSettings objects.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LastUsedFilePathForAnimals", LastUsedFilePathForAnimals);
            info.AddValue("LastUsedFilePathForRecipes", LastUsedFilePathForRecipes);
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
