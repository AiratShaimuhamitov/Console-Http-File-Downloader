namespace HttpFileDownloader.Models.Files
{
    /// <summary>
    /// FileLink model 
    /// </summary>
    public class FileLink
    {
        /// <summary>
        /// File name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Http address of file
        /// </summary>
        public string HttpAddress { get; set; }

        public FileLink(string HttpAddress, string Name)
        {
            this.HttpAddress = HttpAddress;
            this.Name = Name;
        }
    }
}
