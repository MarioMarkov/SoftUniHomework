 namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            foreach (var field in fields)
            {
                if (field.IsPublic)
                {
                    sb.AppendLine("public " + field.FieldType.Name + " " + field.Name);
                }
                else if (field.IsPrivate)
                {
                    sb.AppendLine("private " + field.FieldType.Name + " " + field.Name);
                }
                else if (field.IsFamily)
                {
                    sb.AppendLine("protected " + field.FieldType.Name + " " + field.Name);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="HARVEST")
                {
                    break;
                }
                switch (input)
                {
                    case "protected":
                        foreach (var field in fields)
                        {
                            if (field.IsFamily)
                            {
                                Console.WriteLine("protected " + field.FieldType.Name + " " + field.Name);
                            }
                        }
                        break;
                    case "private":
                        foreach (var field in fields)
                        {
                            if (field.IsPrivate)
                            {
                                Console.WriteLine("private " + field.FieldType.Name +" "+ field.Name);
                            }
                        }
                        break;
                    case "public":
                        foreach (var field in fields)
                        {
                            if (field.IsPublic)
                            {
                                Console.WriteLine("public " + field.FieldType.Name + " " + field.Name);
                            }
                        }
                        break;
                    case "all":
                        Console.WriteLine(sb.ToString().TrimEnd());
                        
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
