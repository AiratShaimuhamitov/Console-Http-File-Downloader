using HttpFileDownloader.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HttpFileDownloader
{
    public class ParameterService
    {        
        private ParameterService() { }

        public static IEnumerable<IParameter> GetParameters(string[] args)
        {
            if (!VerifyArgumentString(args))
                throw new ArgumentException("Wrong parameters");

            var parameters = new List<IParameter>();

            for(var i = 0; i < args.Length; i++)
            {
                if (args[i] == "-n")
                {
                    parameters.Add(new ThreadParameter(args[i], args[i + 1]));
                }
                else if (args[i] == "-l")
                {
                    parameters.Add(new SpeedParameter(args[i], args[i + 1]));
                }
                else if (args[i] == "-f")
                {
                    parameters.Add(new FilePathParameter(args[i], args[i + 1]));
                }
                else if (args[i] == "-o")
                {
                    parameters.Add(new OutputPathParameter(args[i], args[i + 1]));
                }
            }

            return parameters;
        }

        private static bool VerifyArgumentString(string[] args)
        {
            if (args.Length % 2 != 0)
                return false;

            var directives = new List<string>();
            for(var i = 0; i < args.Length; i += 2)
            {
                if (directives.Contains(args[i]))
                    return false;
                else
                    directives.Add(args[i]);
            }
            return true;
        }
    }
}
