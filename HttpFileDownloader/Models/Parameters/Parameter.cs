using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HttpFileDownloader.Parameters
{
    public abstract class Parameter : IParameter
    {
        public string Directive { get; }
        public string Value { get; set; }

        public Parameter(string directive, string value)
        {
            Directive = directive;
            Value = value;

            if (!Verify())
                throw new ArgumentException("Wrong " + GetType().Name + " parameter.");
        }

        public virtual bool Verify()
        {
            return Regex.IsMatch(Directive, "-\\D+");
        }
    }
}
