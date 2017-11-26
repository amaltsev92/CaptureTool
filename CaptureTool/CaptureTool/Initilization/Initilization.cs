using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureTool.Initilization
{
    class Initilization
    {
        private static List<int> standardHotKeys = new List<int> {162, 52};

        private const string registrySettingsName = "CTSettings";
        public static string GetRegistrySettingsName()
        {
            return registrySettingsName;
        }

        private const string registryHotKeysName = "HotKeys";
        public static string GetRegistryHotKeysName()
        {
            return registryHotKeysName;
        }

        private static void StandardHotKeys()
        {
            if (false == WorkWithSystemFiles.WorkerWithReg.KeyExists(registrySettingsName, registryHotKeysName))
            {
                WorkWithSystemFiles.WorkerWithReg.SaveNewHotKeys(standardHotKeys, registrySettingsName, registryHotKeysName);
            }

            PressedKeys.SetDefaultKeys();
        }

        public static void InitForm()
        {
            StandardHotKeys();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}
