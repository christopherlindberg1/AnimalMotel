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
        private string _currentFilePathForAnimals;
        private string _lastUsedFilePathForAnimals;




        /**
         * 
         * ===================  Properties  ===================
         * 
         */

        public string CurrentFilePathForAnimals
        {
            get => _currentFilePathForAnimals;

            set => _currentFilePathForAnimals = value ??
                throw new ArgumentNullException(
                    "CurrentFilePathForAnimals cannot be null",
                    "CurrentFilePathForAnimals");
        }

        public string LastUsedFilePathForAnimals
        {
            get => _lastUsedFilePathForAnimals;

            set => _lastUsedFilePathForAnimals = value ??
                throw new ArgumentNullException(
                    "LastUsedFilePathForAnimals cannot be null",
                    "LastUsedFilePathForAnimals");
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
            info.AddValue("CurrentFilePathForAnimals", CurrentFilePathForAnimals);
            info.AddValue("LastUsedFilePathForAnimals", LastUsedFilePathForAnimals);
        }

        public AppSettings(SerializationInfo info, StreamingContext context)
        {
            CurrentFilePathForAnimals = (string)info.GetValue("CurrentFilePathForAnimals", typeof(string));
            LastUsedFilePathForAnimals = (string)info.GetValue("LastUsedFilePathForAnimals", typeof(string));
        }
    }
}
