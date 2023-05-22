using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class BooksPage
    {
        WebItem SearchField = new WebItem("//input[@name='search']", "Поле поиска");
        WebItem SearchBtn = new WebItem("//button[@class='button book-list-is-info']", "Кнопка поиск");
        WebItem NameBook = new WebItem("//a[@class='book-list-card-name']", "Название книги");
        WebItem DetailBookBtn = new WebItem("//div[@class = 'book-list-card']", "Открыть детальную информацию по книге");
        WebItem FirsBookBtn = new WebItem("//section/main/div[2]/div[1]", "Открыть детальную информацию по первой книги на странице книг");

        public BooksPage SearchBook(Book book)
        {
            SearchField.SendKeys(book.Title);
            SearchBtn.Click();
            return new BooksPage();
        }

        public bool isCorrectName(Book book)
        {
            if (NameBook.InnerText() == book.Title)
                return true;
            else
                return false;
        }

        public DetailBookPage ToDetailBookPage()
        {
            DetailBookBtn.Click();
            return new DetailBookPage();

        }

        public DetailBookPage ToFirstBookDetailPage()
        {
            FirsBookBtn.Click();
            return new DetailBookPage();
        }

    }
}
