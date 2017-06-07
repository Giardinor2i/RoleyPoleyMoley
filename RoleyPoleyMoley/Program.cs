using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoleyPoleyMoley.Convert;
using RoleyPoleyMoley.Reader;

namespace RoleyPoleyMoley
{
    class Program
    {
        static void Main(string[] args)
        {
            //var role = RoleReader.GetRole(@"C:\Dev\Repo\Max\Unicorn\Roles\sitecore\Sitecore Client Users.role");
            //Console.WriteLine(role.ToString());
            //Console.WriteLine("Converted:");
            //Console.WriteLine(YamlConverter.ConvertRoleToYamlString(role));
            YamlConverter.MassConvert(@"C:\Dev\Repo\Max\Unicorn\Roles\sitecore");
            Console.ReadKey();
        }
    }
}
