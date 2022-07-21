using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
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
            var type = Type.GetType(className);
            var classInfo = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            var sb = new StringBuilder();

            var hacker = Activator.CreateInstance(type);

            foreach (var item in classInfo)
            {
                item.
            }
        }
    }
}
