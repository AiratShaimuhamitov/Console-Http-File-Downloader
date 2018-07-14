using System;
using System.Collections.Generic;
using System.Drawing;
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
        private SpeedConfiguration speedConfiguration;
        private OutputConfiguration outputConfiguration;
        private ThreadConfiguration threadConfiguration;

        private void Handle(string[] args)
        {
            var parameters = ParameterUtility.GetParameters(args);

            var filePathParameter = parameters.FirstOrDefault(x => x.GetType() == typeof(FilePathParameter));

            if (filePathParameter == null || string.IsNullOrEmpty(filePathParameter.Value))
            {
                Console.WriteLine("Error: the file path parameter not found.");
                return;
            }

            CreateConfigurationsFromParameters(parameters);

            var downloadService = new DownloadService(
                LinkUtility.GetLinks(filePathParameter.Value),
                outputConfiguration.OutputPath,
                threadConfiguration.ThreadCount,
                speedConfiguration.Speed);
            
            downloadService.Download();
        }

        public static void Main(string[] args)
        {
            var program = new Program();
            program.Handle(args);
            Console.ReadLine();
        }

        private void CreateConfigurationsFromParameters(IEnumerable<Parameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                switch (parameter)
                {
                    case ThreadParameter _:
                        threadConfiguration = new ThreadConfiguration(int.Parse(parameter.Value));
                        break;
                    case SpeedParameter _:
                        speedConfiguration = new SpeedConfiguration(int.Parse(parameter.Value));
                        break;
                    case OutputPathParameter _:
                        outputConfiguration = new OutputConfiguration(parameter.Value);
                        break;
                }
            }
        }
    }
}
