using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Profile;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.BookShelfCreationPage
{
    public class BookshelfCreationPage
    {
        WebItem ShelfNameField = new WebItem("//input[@name='input-bookshelf-name']", "Поле ввода названия полки");
        WebItem ShelfDescriptionField = new WebItem("//input[@name='input-bookshelf-description']", "Поле ввода описания полки");
        WebItem SaveShelfBtn = new WebItem("//input[@class='bookshelf-create-save']", "Кнопка сохранения полки");

       
        public ProfilePage CreateShelf(BookShelf shelf)
        {
            ShelfNameField.SendKeys(shelf.Title);
            ShelfDescriptionField.SendKeys(shelf.Description);
            SaveShelfBtn.Click();
            return new ProfilePage();
        }


    }
}
