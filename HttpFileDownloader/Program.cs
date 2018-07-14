using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using HttpFileDownloader.Configurations;
using HttpFileDownloader.Parameters;
using HttpFileDownloader.Services;
using HttpFileDownloader.Utilities;
using NUnit.Framework;

namespace HttpFileDownloader
{
    public class Program
    {
        private void Handle(string[] args)
        {
            var parameters = ParameterUtility.GetParameters(args);

            var filePathParameter = parameters.FirstOrDefault(x => x.GetType() == typeof(FilePathParameter));

            if (filePathParameter == null || string.IsNullOrEmpty(filePathParameter.Value) || File.Exists(filePathParameter.Value))
            {
                Console.WriteLine("Error: the file path parameter not found.");
                return;
            }

            var outputPath = parameters.First(x => x is OutputPathParameter).Value;
            var threadCount = int.Parse(parameters.First(x => x is ThreadParameter).Value);
            var speed = int.Parse(parameters.First(x => x is SpeedParameter).Value);

            var downloadService = new DownloadService(
                FileLinkUtility.GetFileLinks(filePathParameter.Value),
                outputPath,
                threadCount,
                speed);
            
            downloadService.Download();
        }

        public static void Main(string[] args)
        {
            var program = new Program();
            program.Handle(args);
            Console.ReadLine();
        }
    }
}
