using System;
using System.Collections.Generic;
using HttpFileDownloader.Parameters;

namespace HttpFileDownloader.Utilities
{
    public class ParameterUtility
    {        
        private ParameterUtility() { }

        /// <summary>
        /// Get parameters from string. 
        /// </summary>
        /// <param name="args">Parameters from console</param>
        /// <returns>Collection of parameters</returns>
        public List<Parameter> GetParameters(string[] args)
        {
            if (!VerifyArgumentString(args))
                throw new ArgumentException("Wrong parameters");

            var parameters = new List<Parameter>();

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
        
        /// <summary>
        /// Verify argument string 
        /// </summary>
        private bool VerifyArgumentString(string[] args)
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

        /// <summary>
        /// Verify parameters
        /// </summary>
        private void VerifyParameters(IEnumerable<Parameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                parameter.Verify();
            }
        } 
    }
}
