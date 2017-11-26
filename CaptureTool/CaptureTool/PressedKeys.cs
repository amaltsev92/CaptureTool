using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;

namespace CaptureTool
{
    class PressedKeys
    {
        private static List<int> currentPressedKeys = new List<int>();

        private static List<int> defaultKeys = new List<int>();
        public static void SetDefaultKeys()
        {
            defaultKeys = WorkWithSystemFiles.WorkerWithReg.GetHotKeys(
                Initilization.Initilization.GetRegistrySettingsName()
                , Initilization.Initilization.GetRegistryHotKeysName());
        }

        private static bool AreListsEqual(List<int> list1, List<int> list2)
        {
            var firstNotSecond = list1.Except(list2).ToList();
            var secondNotFirst = list2.Except(list1).ToList();

            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }

        public static void SavePressedKey(int newKey)
        {
            if (currentPressedKeys.Contains(newKey))
                return;

            currentPressedKeys.Add(newKey);
        }

        public static void CheckPressedKeys()
        {
            if (AreListsEqual(defaultKeys, currentPressedKeys))
            {
                WorkWithSystemFiles.MakeScreenshot.Make_Full_Screenshot();
            }
        }

        public static void DeleteAnPressedKey(int anPressedKey)
        {
            currentPressedKeys.Remove(anPressedKey);
        }

        public static void SaveNewHotKeys()
        {
            WorkWithSystemFiles.WorkerWithReg.SaveNewHotKeys(currentPressedKeys
                , Initilization.Initilization.GetRegistrySettingsName()
                , Initilization.Initilization.GetRegistryHotKeysName());

            SetDefaultKeys();
        }



        public static string CurrentPressedKeys()
        {
            string currentHotKeys = "";

            foreach (int hotKeys in currentPressedKeys)
            {
                currentHotKeys = currentHotKeys + ((Keys)hotKeys).ToString() + " + ";
            }

            return currentHotKeys.Remove(currentHotKeys.Length - 3);
        }

        public static string DefaultPressedKeys()
        {
            string defaultHotKeys = "";

            foreach (int hotKeys in defaultKeys)
            {
                defaultHotKeys = defaultHotKeys + ((Keys)hotKeys).ToString() + " + ";
            }

            return defaultHotKeys.Remove(defaultHotKeys.Length - 3);
        }


    }
}
