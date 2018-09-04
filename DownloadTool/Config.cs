using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadTool
{
    public static class Config
    {
        public static readonly List<Tuple<string, string>> NameMappings = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("animal2017", "动物"),
            new Tuple<string, string>("device2017", "硬件"),
            new Tuple<string, string>("goose2017", "鹅"),
            new Tuple<string, string>("bundam2017", "高达"),
            new Tuple<string, string>("face2017", "麻将"),
        };
    }
}
