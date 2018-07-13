namespace HttpFileDownloader.Models.Files
{
    /// <summary>
    /// Link model 
    /// </summary>
    public class Link
    {
        public string Name { get; set; }
        public string HttpAddress { get; set; }

        public Link(string HttpAddress, string Name)
        {
            this.HttpAddress = HttpAddress;
            this.Name = Name;
        }
    }
}
