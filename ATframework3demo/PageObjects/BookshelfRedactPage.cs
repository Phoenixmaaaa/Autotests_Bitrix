using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class BookshelfRedactPage
    {
        WebItem BookName(string bookName) => new WebItem($"//p[text()='{bookName}']", "Локатор для названия книги на странице редактирования");
        public bool IsBookOnShelf(Book book)
        {
            if (BookName(book.Title).AssertTextContains(book.Title, "Книги нет на полке"))
                return true;
            else
                return false;

        }
    }
}
