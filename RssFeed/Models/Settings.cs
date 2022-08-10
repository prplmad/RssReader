namespace RssFeed.Models
{
    public class Settings
    {
        public bool DescriptionTags { get; set; }
        public string[] Url { get; set; } = new string[5];
        public int UpdateTime { get; set; }
    }
}
