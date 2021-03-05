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
        // Fields for all settings
        //private string _currentFilePathForAnimals;
        private string _lastUsedFilePathForAnimals;
        private string _lastUsedFilePathForRecipes;




        /**
         * 
         * ===================  Properties  ===================
         * 
         */

        //public string CurrentFilePathForAnimals
        //{
        //    get => _currentFilePathForAnimals;

        //    set => _currentFilePathForAnimals = value ??
        //        throw new ArgumentNullException(
        //            "CurrentFilePathForAnimals cannot be null",
        //            "CurrentFilePathForAnimals");
        //}

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
        }

        /// <summary>
        /// Creates a deep copy of an AppSettings object.
        /// </summary>
        /// <param name="appSettings">AppSettings object to copy</param>
        public AppSettings(AppSettings appSettings)
        {
            throw new NotImplementedException();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("CurrentFilePathForAnimals", CurrentFilePathForAnimals);
            info.AddValue("LastUsedFilePathForAnimals", LastUsedFilePathForAnimals);
            info.AddValue("LastUsedFilePathForRecipes", LastUsedFilePathForRecipes);
        }

        public AppSettings(SerializationInfo info, StreamingContext context)
        {
            //CurrentFilePathForAnimals = (string)info.GetValue("CurrentFilePathForAnimals", typeof(string));
            LastUsedFilePathForAnimals = (string)info.GetValue("LastUsedFilePathForAnimals", typeof(string));
            LastUsedFilePathForRecipes = (string)info.GetValue("LastUsedFilePathForRecipes", typeof(string));
        }
    }
}
