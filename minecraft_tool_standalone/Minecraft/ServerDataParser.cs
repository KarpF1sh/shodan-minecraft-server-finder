using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minecraft_tool_standalone.Shodan;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace minecraft_tool_standalone.Minecraft
{
    internal static class ServerDataParser
    {
        // Dictionary to group strings to find with their correct types
        private static readonly Dictionary<string, DataType> mineDict = new Dictionary<string, DataType>
        {
            // Maybe reverse these some day
            {"Version: ", DataType.VERSION},
            {"Description: ", DataType.DESCRIPTION},
            {"Online Players: ", DataType.ONLINE},
            {"Maximum Players: ", DataType.MAX}
        };
        public static ServerData Parse(string data)
        {
            // Create holder for server info
            ServerData serverData = new ServerData();

            // Loop through lines ++
            using (var reader = new StringReader(data))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    foreach (var item in mineDict)
                    {
                        // If line has the wanted value..
                        if (line.Contains(item.Key) && line != String.Empty)
                        {
                            // Get data after specific string
                            string parsedString = line.Substring(line.IndexOf(item.Key) + item.Key.Length);
                            if (item.Value == DataType.VERSION)
                            {
                                try
                                {
                                    parsedString = parsedString.Substring(0, parsedString.ToLower().LastIndexOf("(protocol"));
                                } catch {
                                    Console.WriteLine("FAILED WITH STRING: " + line);
                                }
                                //Console.Write(parsedString.Substring(0, parsedString.LastIndexOf("(Protocol")));
                            }
                            serverData.SetDataValues(item.Value, parsedString);
                        }
                    }
                }
            }

            // Log for funz
            Console.WriteLine(serverData.ToString());

            // return data
            return serverData;
        }
    }
}
