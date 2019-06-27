using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) == 0)
            {
                return this.Age.CompareTo(other.Age);
            }
            return this.Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)
        {
            if (obj is Person other)
            {
                return this.Name == other.name && this.Age == other.Age;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
