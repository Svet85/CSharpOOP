
namespace Stealer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public Spy()
        {

        }
        public string StealFieldInfo(string className, params string[] fieldsNames)
        {

            var type = Type.GetType(className);
            var classInfo = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            var sb = new StringBuilder();
            
            var hacker = Activator.CreateInstance(type);

            sb.AppendLine($"Class under investigation: {className}");

            foreach (var field in classInfo)
            {
                if (fieldsNames.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(hacker)}");
                }
            }

            return sb.ToString().Trim();
            
        }
        public string AnalyzeAccessModifiers(string className)
        {
            var aa = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == className);

            Type type = Type.GetType(aa.FullName);
            var classInfo = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            var sb = new StringBuilder();

            foreach (var field in classInfo)
            {
                    sb.AppendLine($"{field.Name} must be private!");
            }

            var methodsPublic = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            var methodsNonPublic = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var method in methodsNonPublic.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in methodsPublic.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }
    }
}
