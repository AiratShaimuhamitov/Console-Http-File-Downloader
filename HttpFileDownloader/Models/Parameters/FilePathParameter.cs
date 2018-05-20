using System;
using System.Text.RegularExpressions;

namespace HttpFileDownloader.Parameters
{
    public class FilePathParameter : Parameter
    {
        public FilePathParameter(string directive, string value) : base(directive, value)
        {      
        }

        public override bool Verify()
        {
            return Regex.IsMatch(Value, "\\w*\\.txt");
        }
    }
}
