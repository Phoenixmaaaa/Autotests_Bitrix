using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Profile;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class FormToAddBook
    {
        WebItem TitleBookField = new WebItem("//input[@name='input-book-title']", "Поле для ввода названия книги");
        WebItem AuthorBookField = new WebItem("//input[@class='bookshelf-create-author']", "Поле для ввода имени автора");
        WebItem SaveBookBtn = new WebItem("//input[@class='book-create-save']", "Кнопка сохранить");

        public ProfilePage AddNewBook (Book book)
        {
            TitleBookField.SendKeys(book.Title);
            AuthorBookField.SendKeys(book.Author);
            SaveBookBtn.Click();
            return new ProfilePage();
        }
    }
}
