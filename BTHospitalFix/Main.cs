using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[assembly: AssemblyVersion("1.0.0.0")]

namespace BTHospitalFix
{
    class Main
    {
        public static void Init(string directory, string settingsJSON)
        {
            var harmony = HarmonyInstance.Create("com.github.mcb5637.BTHospitalFix");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
