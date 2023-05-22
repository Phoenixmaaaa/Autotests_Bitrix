namespace ATframework3demo.TestEntities
{
    public class Book
    {
        public Book()
        {

        }
        public Book(string title = "title", string author = "author")
        {
            this.Title = title;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
