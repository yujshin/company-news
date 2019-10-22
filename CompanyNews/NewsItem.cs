namespace CompanyNews
{
    public class NewsItem
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ContentBrief => $"{Content.Substring(0, 20)}...";
        public string ImageUrl { get; set; }
        public bool ShouldHardCrash { get; set; }
        public bool ShouldHandledError { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
