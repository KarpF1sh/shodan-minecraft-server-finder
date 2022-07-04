using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minecraft_tool_standalone.Minecraft
{
    internal class ServerData
    {
        private static string Version { get; set; }
        private static string Description { get; set; }
        private static string Online_Players { get; set; }
        private static string Maximum_Players { get; set; }

        public override string ToString() => $"ver={Version}, desc={Description}, online={Online_Players}, max={Maximum_Players}";
        
        public ServerData()
        {
            // Empty constructor
        }

        public void SetDataValues(DataType type, string value)
        {
            switch (type)
            {
                case DataType.VERSION:
                    Version = value;
                    break;

                case DataType.DESCRIPTION:
                    Description = value;
                    break;

                case DataType.ONLINE:
                    Online_Players = value;
                    break;

                case DataType.MAX:
                    Maximum_Players = value;
                    break;
            }
        }

        public string GetDataValues(DataType type)
        {
            switch (type)
            {
                case DataType.VERSION:
                    return Version;

                case DataType.DESCRIPTION:
                    return Description;

                case DataType.ONLINE:
                    return Online_Players;

                case DataType.MAX:
                    return Maximum_Players;

                default:
                    // None matched
                    return null;
            }
        }
    }
}
