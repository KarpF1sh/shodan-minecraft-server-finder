using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minecraft_tool_standalone.Reg
{
    internal static class Manager
    {
        // Rushed implementation

        // Create key if it does not exist
        private static void CreateRegistryKey()
        {
            // Open key
            if (Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MinecraftTool") != null)
            {
                // Already created
                return;
            }
            else
            {
                // Create new keys
                RegistryKey keyNew = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MinecraftTool");
                keyNew.SetValue("key", String.Empty);
                keyNew.SetValue("gamePath", String.Empty);
                keyNew.Close();
            }
        }
        // Get wanted key based on type
        public static string GetRegistryKey(KeyType type)
        {
            // Open key
            RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MinecraftTool");
            if (Key != null && Key.GetValue("key") != null)
            {
                // Switch to get the right key value
                switch (type)
                {
                    case KeyType.APIKEY:
                        return Key.GetValue("key").ToString();

                    case KeyType.GAMEPATH:
                        return Key.GetValue("gamePath").ToString();
                    default: return String.Empty;
                }
            }
            else
            { 
                // just in case
                CreateRegistryKey();
                return String.Empty;
            }
        }

        // Set wanted key based on type
        public static void SetRegistryKey(KeyType type, string value)
        {
            // Open key if not null
            RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MinecraftTool", true);
            if (Key != null)
            {
                // Switch to choose right key
                switch (type)
                {
                    case KeyType.APIKEY:
                        Key.SetValue("key", value);
                        break;

                    case KeyType.GAMEPATH:
                        Key.SetValue("gamePath", value);
                        break;
                }

                // Close key access
                Key.Close();
            }
            else { // just in case
                   CreateRegistryKey(); }
        }
    }
}
