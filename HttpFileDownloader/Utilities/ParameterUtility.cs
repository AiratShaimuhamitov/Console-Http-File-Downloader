using System;
using System.Collections.Generic;
using HttpFileDownloader.Parameters;

namespace HttpFileDownloader.Utilities
{
    public static class ParameterUtility
    {        
        /// <summary>
        /// Get parameters from string. 
        /// </summary>
        /// <param name="args">Parameters from console</param>
        /// <returns>Collection of parameters</returns>
        public static List<Parameter> GetParameters(string[] args)
        {
            if (!VerifyArgumentString(args))
                throw new ArgumentException("Wrong parameters");

            var parameters = new List<Parameter>();

            for(var i = 0; i < args.Length; i++)
            {
                Parameter parameter = null;

                if (args[i] == "-n")
                    parameter = new ThreadParameter(args[i], args[i + 1]);
                else if (args[i] == "-l")
                {
                    parameter = new SpeedParameter(args[i], args[i + 1]);
                }
                else if (args[i] == "-f")
                {
                    parameter = new FilePathParameter(args[i], args[i + 1]);
                }
                else if (args[i] == "-o")
                {
                    parameter = new OutputPathParameter(args[i], args[i + 1]);
                }

                if (parameter != null && parameter.Verify())
                    parameters.Add(parameter);
            }

            return parameters;
        }
        
        /// <summary>
        /// Verify argument string 
        /// </summary>
        private static bool VerifyArgumentString(string[] args)
        {
            if (args.Length % 2 != 0)
                return false;

            var directives = new List<string>();
            for(var i = 0; i < args.Length; i += 2)
            {
                if (directives.Contains(args[i]))
                    return false;
                directives.Add(args[i]);
            }
            return true;
        }
    }
}
