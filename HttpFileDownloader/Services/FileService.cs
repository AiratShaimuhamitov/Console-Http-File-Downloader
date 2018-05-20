using HttpFileDownloader.Models.Files;
using HttpFileDownloader.Parameters;
using System.Collections.Generic;

namespace HttpFileDownloader.Services
{
    public class FileService
    {
        public FilePathParameter PathParameter { get; set; }

        public FileService(FilePathParameter pathParameter)
        {
            this.PathParameter = pathParameter;
        }

        public List<File> GetFiles()
        {
            string filePath = PathParameter.Value;

            string[] httpPaths = System.IO.File.ReadAllText(filePath).Split(' ');

            var files = new List<File>();

            foreach(var path in httpPaths)
            {
                files.Add(new File(path));
            }

            return files;
        }
    }
}
