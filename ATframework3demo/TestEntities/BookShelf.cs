namespace ATframework3demo.TestEntities
{
    public class BookShelf
    {
        public BookShelf()
        {

        }
        public BookShelf(string title, string description = "descripthion")
        {
            this.Title = title;
            this.Description = description;
        }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
