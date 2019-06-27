namespace Exercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> simpleSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);
                Person person = new Person(name, age);
                simpleSet.Add(person);
                hashSet.Add(person);
            }
            Console.WriteLine(simpleSet.Count);
            Console.WriteLine(hashSet.Count);
            
           
        }
    }
}
