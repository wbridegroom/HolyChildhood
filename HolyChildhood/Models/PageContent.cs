namespace HolyChildhood.Models
{
    public class PageContent
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Page Page { get; set; }
    }
}