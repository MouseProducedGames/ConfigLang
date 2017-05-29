using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigLang.ConsoleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigReader reader = new ConfigReader(Properties.Resources.config);

            Console.WriteLine(reader.ReadConfigBool("Works"));
            Console.WriteLine(reader.ReadConfigDouble("Works2"));
            Console.WriteLine(reader.ReadConfigLong("ThisIsAnInt"));
            Console.WriteLine(reader.ReadConfigString("ThisIsAnIdent"));

            Console.ReadKey(true);
        }
    }
}
