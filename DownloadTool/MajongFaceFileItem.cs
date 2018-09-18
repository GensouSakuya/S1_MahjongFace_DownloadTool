using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadTool
{
    public class MajongFaceFileItem
    {
        public string LocFolderName { get; set; }
        public string UrlFolderName { get; set; }
        public string FileName { get; set; }

        public MajongFaceFileItem(string locName, string urlName, string fileName)
        {
            LocFolderName = locName;
            UrlFolderName = urlName;
            FileName = fileName;
        }
    }
}
