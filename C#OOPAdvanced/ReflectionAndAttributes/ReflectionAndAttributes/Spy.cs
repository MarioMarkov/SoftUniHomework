using System;
using System.Reflection;
using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");

            var type = Type.GetType(className);
            
            var instance = Activator.CreateInstance(type);
            for (int i = 0; i < fieldsNames.Length; i++)
            {
                var currentField = type.GetField(fieldsNames[i],BindingFlags.Public| BindingFlags.Static| 
                    BindingFlags.NonPublic| BindingFlags.Instance);

                var value = currentField.GetValue(instance);
                sb.AppendLine($"{currentField.Name} = {value}");
            }
            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            var type = Type.GetType(className);

            var instance = Activator.CreateInstance(type);

            var fields = type.GetFields((BindingFlags)62);
        var allMethods = type.GetMethods((BindingFlags)62);
            foreach (var field in fields)
            {
                if (field.IsPublic)
                {
                sb.AppendLine($"{field.Name} must be private!");
                }
            }
            
        foreach (var method in allMethods)
        {
            if (method.ge)
            {

            }
        }
            
        }
    }

