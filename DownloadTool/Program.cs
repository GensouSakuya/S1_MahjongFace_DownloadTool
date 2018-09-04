using System.IO;
using System.Threading.Tasks;
using static DownloadTool.HttpDownloadExtend;

namespace DownloadTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.ForEach(Config.NameMappings, t =>
            {
                for (int i = 1; i <= 300; i++)
                {
                    HttpDownload($"https://static.saraba1st.com/image/smiley/{t.Item1}/{i.ToString().PadLeft(3, '0')}.png",
                        $@"{Directory.GetCurrentDirectory()}\麻将脸\{t.Item2}");
                }
            });
        }
    }
}
