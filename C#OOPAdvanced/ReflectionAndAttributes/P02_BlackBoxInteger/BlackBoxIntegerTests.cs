namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            var instance = (BlackBoxInteger)Activator.CreateInstance(type, true);
            while (true)
            {
                string[] input = Console.ReadLine().Split("_");
                if (input[0] == "END")
                    break;
                string methodName = input[0];
                int methodParam = int.Parse(input[1]);
                var currMethod = type.GetMethod(methodName,(BindingFlags)62);
                currMethod.Invoke(instance, new object[] { methodParam});
                 var field = instance.GetType().GetField("innerValue", (BindingFlags)62);
                var value = field.GetValue(instance);
                Console.WriteLine(value);
                

            }
        }
    }
}
