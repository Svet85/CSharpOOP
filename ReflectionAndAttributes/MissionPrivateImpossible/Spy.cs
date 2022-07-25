namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public Spy()
        {

        }

        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] info = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            
            sb.AppendLine($"Class under investigation: {className}");

            foreach (var field in info.Where(f => fieldNames.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            var type = Type.GetType(className);
            var privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }


            return sb.ToString().Trim();
        }
    }
}
