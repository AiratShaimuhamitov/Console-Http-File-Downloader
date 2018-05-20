using System.Text.RegularExpressions;

namespace HttpFileDownloader.Parameters
{
    public class OutputPathParameter : Parameter
    {
        public OutputPathParameter(string directive, string value) : base(directive, value)
        {
        }

        public override bool Verify()
        {
            return base.Verify() && Regex.IsMatch(Value, "\\D+");
        }
    }
}
