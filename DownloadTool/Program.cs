using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static DownloadTool.HttpDownloadExtend;

namespace DownloadTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = Config.NameMappings.Select(async t =>
            {
                for (int i = 1; i <= 300; i++)
                {
                    await HttpDownload($"https://static.saraba1st.com/image/smiley/{t.Item1}/{i.ToString().PadLeft(3, '0')}.png",
                        $@"{Directory.GetCurrentDirectory()}\麻将脸\{t.Item2}");
                    await HttpDownload($"https://static.saraba1st.com/image/smiley/{t.Item1}/{i.ToString().PadLeft(3, '0')}.gif",
                        $@"{Directory.GetCurrentDirectory()}\麻将脸\{t.Item2}");
                }
            });
            Task.WaitAll(tasks.ToArray());
        }
    }
}
