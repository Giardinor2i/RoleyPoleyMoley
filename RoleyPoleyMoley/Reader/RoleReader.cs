using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoleyPoleyMoley.Types;

namespace RoleyPoleyMoley.Reader
{
    public static class RoleReader
    {
        public static Role GetRole(string filePath)
        {
            try
            {
                var lines = File.ReadLines(filePath);
                var roleName = lines.First(r => r.StartsWith("name:")).Substring(6);
                var newRole = new Role(roleName, true, true);

                var roleInRoles = lines.Where(r => r.StartsWith("rolename:"));
                foreach (var innerRole in roleInRoles)
                {
                    newRole.AddRole(innerRole.Substring(10));
                }

                return newRole;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
