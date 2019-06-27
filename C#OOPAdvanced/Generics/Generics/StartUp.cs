using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //           •	Add < element > -Adds the given element to the end of the list
            //•	Remove < index > -Removes the element at the given index
            //•	Contains < element > -Prints if the list contains the given element(True or False)
            //•	Swap<index> < index > -Swaps the elements at the given indexes
            //•	Greater < element > -Counts the elements that are greater than the given element and prints their count
            //•	Max - Prints the maximum element in the list
            //•	Min - Prints the minimum element in the list
            //•	Print - Prints all of the elements in the list, each on a separate line
            //•	END - stops the reading of commands
            ICustomList<string> customList = new CustomList<string>();
            while (true)
            {
                string[] line = Console.ReadLine().Split();
                if (line[0]=="END")
                {
                    break;
                }
                switch (line[0])
                {
                    case "Add" :customList.Add(line[1]);
                        break;
                    case "Remove":
                        customList.Remove(int.Parse(line[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(customList.Contains(line[1]));
                        break;
                    case "Swap":
                        customList.Swap(int.Parse(line[1]), int.Parse(line[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(customList.CountGreaterThan(line[1]));
                        break;
                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;
                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;
                    case "Print":
                        foreach (var item in customList)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "Sort":
                        customList.Sort();
                        break;

                    default: throw new InvalidOperationException("Invalid operation!");
                        break;
                }
            }

        }
    }
}
