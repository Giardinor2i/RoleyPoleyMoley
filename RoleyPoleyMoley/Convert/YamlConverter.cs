using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoleyPoleyMoley.Reader;
using RoleyPoleyMoley.Types;

namespace RoleyPoleyMoley.Convert
{
    public static class YamlConverter
    {
        public static string ConvertRoleToYamlString(Role role)
        {
            var builder = new StringBuilder();
            builder.AppendLine("---\nRole: |");
            builder.AppendLine($"  {role.Name}");
            if (role.InRoles.Any())
            {
                builder.AppendLine("MemberOf:");
                foreach (var innerRole in role.InRoles)
                {
                    builder.AppendLine("  Role: |");
                    builder.AppendLine($"    {innerRole.Name}");
                }
            }
            return builder.ToString();
        }

        public static void ConvertRoleToYamlFile(string inFile, string outFile)
        {
            var roleToConvert = RoleReader.GetRole(inFile);
            var convertedString = ConvertRoleToYamlString(roleToConvert);
            File.WriteAllText(outFile, convertedString);
        }

        public static void MassConvert(string startPath)
        {
            foreach(var file in new DirectoryInfo(startPath).GetFiles().Where(r=>r.Extension.Equals(".role")))
            {
                var newName = file.Directory.FullName + "\\" + file.Name.Substring(0, file.Name.Length - 5) + ".yml";
                ConvertRoleToYamlFile(file.FullName, newName);
            }
        }
    }
}
