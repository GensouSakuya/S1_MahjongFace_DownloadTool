using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DownloadTool
{
    public static class HttpDownloadExtend
    {
        public static async Task<bool> HttpDownload(string url, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var urlFileName = url.Split('/').LastOrDefault();
            string fileName = path + @"\" + urlFileName ?? "aaa.temp";
            if (File.Exists(fileName))
            {
                return true;
            }

            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
                using (Stream responseStream = response.GetResponseStream())
                {
                    byte[] bArr = new byte[1024];
                    int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    if (size == 0)
                    {
                        return false;
                    }
                    using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    {
                        while (size > 0)
                        {
                            fs.Write(bArr, 0, size);
                            size = responseStream.Read(bArr, 0, (int) bArr.Length);
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
