using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel
{
    public class Staff
    {
        private string _name;
        private readonly IListManager<string> _qualifications = new ListManager<string>();




        // ========================= Properties ========================= //

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public IListManager<string> Qualifications
        {
            get { return _qualifications; }
        }




        // ========================= Methods ========================= //







        public override string ToString()
        {
            StringBuilder staffString = new StringBuilder();

            staffString.Append($"{ Name }. ");
            staffString.Replace(staffString[0],
                char.Parse(staffString[0].ToString().ToUpper()));

            for (int i = 0; i < Qualifications.Count; i++)
            {
                staffString.Append($"{Qualifications[i]}, ");
            }

            return staffString.ToString();
        }
    }
}
