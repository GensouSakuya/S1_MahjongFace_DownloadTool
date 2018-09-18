using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static DownloadTool.HttpDownloadExtend;

namespace DownloadTool
{
    public class MajongFaceHelper
    {
        public static List<MajongFaceFileItem> GetAllMajongFace()
        {
            var js = GetTextResponse("https://bbs.saraba1st.com/2b/data/cache/common_smilies_var.js?Huq");

            var lines = js.Split(';').ToList();
            var typesjs = lines.Where(p => p.StartsWith("smilies_type[")).ToList();
            var types = new List<MajongFaceType>();
            var regItm = new Regex(@"\['.*']");
            var regId = new Regex(@"_\d+");
            typesjs.ForEach(p =>
            {
                var objstr = regItm.Match(p).ToString();
                var strList = objstr.Split('=').Select(q => q.Trim()).ToList();
                var idStr = regId.Match(strList[0]).ToString().Replace("_", "").ToString();

                int id = 0;
                if (!int.TryParse(idStr, out id))
                    return;

                var nameli = strList[1].Replace("[", "").Replace("]", "").Replace("'", "").Split(',').Select(q => q.Trim()).ToList();

                types.Add(new MajongFaceType(id, nameli[0], nameli[1]));
            });

            var facejs = lines.Where(p => p.StartsWith("smilies_array[")).ToList();
            var faces = new List<MajongFaceFileItem>();
            types.ForEach(type =>
            {
                var regId2 = new Regex($@"smilies_array\[{type.ID}]");
                var thisTypeFaceJs = facejs.Where(p => regId2.IsMatch(p)).Select(p => p.Split('=').Last().Trim()).ToList();
                if (!thisTypeFaceJs.Any())
                    return;
                thisTypeFaceJs.ForEach(array =>
                {
                    var filenames = array.Replace("'", "").Split(',').Where(p => p.Contains(".")).ToList();
                    faces.AddRange(filenames.Select(p => new MajongFaceFileItem(type.ChiName, type.EngName, p)));
                });
            });

            return faces;
        }

        public static void StartDownload(List<MajongFaceFileItem> majongItems,string folderPath = null)
        {
            if (folderPath == null)
            {
                folderPath = Directory.GetCurrentDirectory();
            }

            var downloadUrl = "https://static.saraba1st.com/image/smiley";
            var tasks = majongItems.Select(async t =>
            {
                await HttpDownload($"{downloadUrl}/{t.UrlFolderName}/{t.FileName}", $@"{folderPath}\麻将脸\{t.LocFolderName}", t.FileName);
            });
            Task.WaitAll(tasks.ToArray());
        }
    }
}
