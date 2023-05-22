using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class BookListPage
    {
        WebItem FirstBookInList = new WebItem("//div[@class='book-list-card'][1]//a[@class='book-list-card-name']", "Первая книга на странице списка книг");


        public BooksPage OpenFirstBookPage()
        {
            FirstBookInList.Click();
            return new BooksPage();
        }
    }
}
