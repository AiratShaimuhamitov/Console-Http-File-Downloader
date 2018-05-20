using System;

namespace HttpFileDownloader
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            var parameters = ParameterService.GetParameters(args);
            foreach(var param in parameters)
            {
                Console.WriteLine(param.Directive + " " + param.Value);
            }
            Console.ReadLine();
        }
    }
}
