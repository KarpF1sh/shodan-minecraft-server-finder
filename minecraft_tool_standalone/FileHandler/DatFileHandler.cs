using fNbt;
using minecraft_tool_standalone.Reg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minecraft_tool_standalone.FileHandler
{
    internal static class DatFileHandler
    {
        private static string path;
        private static string datFileOriginal;
        private static string datFileBackup;
        private static string datFileBackupMinecraft;

        public static void FileBackup()
        {
            // Get path from registry
            path = Manager.GetRegistryKey(KeyType.GAMEPATH);

            if (path != String.Empty)
            {
                // Backup server list
                datFileOriginal = path + "\\servers.dat";
                datFileBackup = path + "\\servers.dat.mctool";
                datFileBackupMinecraft = path + "\\servers.dat_old";

                if (File.Exists(datFileOriginal))
                {
                    File.Copy(datFileOriginal, datFileBackup, true);
                } else
                {
                    //new empty server file
                    NbtCompound compound = new NbtCompound("");

                    /*compound.Add(new NbtList("servers")
                    {
                        new NbtCompound() {
                            new NbtString("ip", ""),
                            new NbtString("name", "")
                        }
                    });*/

                    // Save empty file
                    WriteFile(new NbtFile(compound));
                }
                    
            }
        }

        public static void FileClean()
        {
            if (File.Exists(datFileBackup))
            {
                try
                {
                    // Delete the old server list file and bakcup
                    File.Delete(datFileOriginal);
                    File.Delete(datFileBackupMinecraft);
                } catch { }

                // Copy the backed up old server list file back
                File.Copy(datFileBackup, datFileOriginal, true);

                // Delete mctool backup only if wanted
                //File.Delete(datFileBackup);
            }
        }

        public static void WriteFile(NbtFile file)
        {
            // Delete the old server list file and bakcup
            File.Delete(datFileOriginal);
            File.Delete(datFileBackupMinecraft);

            file.SaveToFile(datFileOriginal, NbtCompression.None);
        }
    }
}
