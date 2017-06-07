using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleyPoleyMoley.Types
{
    public class Role
    {
        public string Name { get; set; }
        public bool IsRoot { get; set; }
        public List<Role> InRoles { get; set; }

        public Role(string name, bool isRoot, bool initRoleList = false)
        {
            this.Name = name;
            this.IsRoot = isRoot;
            if(initRoleList)
                this.InRoles = new List<Role>();
        }

        public void AddRole(string roleName)
        {
            this.InRoles.Add(new Role(roleName, false));
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Role name: {this.Name}");
            builder.AppendLine($"IsRoot: {this.IsRoot}");
            builder.AppendLine("Inner Roles:");
            foreach (var role in InRoles)
            {
                builder.AppendLine($"\t{role.Name}");
            }
            return builder.ToString();
        }
    }
}
