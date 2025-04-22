namespace BusinessNewsApp.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public Source Source { get; set; }
    }

    public class Source
    {
        public string Name { get; set; }
    }

    public class NewsResponse
    {
        public List<Article> Articles { get; set; }
    }
}
