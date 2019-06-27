using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise
{
    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.Length.CompareTo(y.Name.Length) == 0)
            {
                return x.Name.ElementAt(0).ToString().ToLower().CompareTo(y.Name.ElementAt(0).ToString().ToLower());
            }
            return x.Name.Length.CompareTo(y.Name.Length);
        } 
    }
}
