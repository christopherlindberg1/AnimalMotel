using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    //[Serializable]
    public class RecipeManager : ListManager<Recipe>
    {
        public RecipeManager()
        {

        }

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("List", List);
        //}

        //public RecipeManager(SerializationInfo info, StreamingContext context)
        //{
        //    List = (List<Recipe>)info.GetValue("List", typeof(List<Recipe>));
        //}
    }
}
