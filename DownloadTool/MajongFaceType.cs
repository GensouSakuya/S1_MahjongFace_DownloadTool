using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadTool
{
    public class MajongFaceType
    {
        public int ID { get; set; }
        public string ChiName { get; set; }
        public string EngName { get; set; }

        public MajongFaceType(int id, string cName, string eName)
        {
            ID = id;
            ChiName = cName;
            EngName = eName;
        }
    }
}
