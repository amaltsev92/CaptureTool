using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace CaptureTool.WorkWithSystemFiles
{
    class WorkerWithReg
    {
        public static bool KeyExists(string registrySettingsName, string registryHotKeysName)
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            string[] allSubKeysNames = currentUserKey.GetSubKeyNames();

            if (false == allSubKeysNames.Contains(registrySettingsName))
                return false;

            RegistryKey settingsKey = currentUserKey.CreateSubKey(registrySettingsName);

            allSubKeysNames = settingsKey.GetSubKeyNames();

            if (false == allSubKeysNames.Contains(registryHotKeysName))
                return false;

            settingsKey = currentUserKey.CreateSubKey(registrySettingsName)
                .CreateSubKey(registryHotKeysName);

            allSubKeysNames = settingsKey.GetValueNames();

            return (allSubKeysNames.Count() != 1);
        }

        public static List<int> GetHotKeys(string registrySettingsName, string registryHotKeysName)
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey settingsKey = currentUserKey.CreateSubKey(registrySettingsName)
                .CreateSubKey(registryHotKeysName);

            List<int> tmpHotKeys = new List<int>();

            foreach (string key in settingsKey.GetValueNames())
            {
                tmpHotKeys.Add((int)settingsKey.GetValue(key));
            }

            return tmpHotKeys;
        }

        public static void SaveNewHotKeys(List<int> newDefaultKeys
            , string registrySettingsName, string registryHotKeysName)
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey settingsKey;

            if (KeyExists(registrySettingsName, registryHotKeysName))
            {
                settingsKey = currentUserKey.CreateSubKey(registrySettingsName);

                settingsKey.DeleteSubKey(registryHotKeysName);

                settingsKey.Close();
            }

            settingsKey = currentUserKey.CreateSubKey(registrySettingsName)
                .CreateSubKey(registryHotKeysName);

            foreach (int hotKey in newDefaultKeys)
            {
                settingsKey.SetValue(hotKey.ToString(), hotKey);
            }

            settingsKey.Close();
        }
    }
}
