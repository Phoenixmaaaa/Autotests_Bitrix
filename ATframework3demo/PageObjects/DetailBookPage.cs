using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Profile;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class DetailBookPage
    {
        WebItem AddWillReadBtn = new WebItem("//button[@id = 'button-add-willread']", "Добавить книгу в буду читать");
        WebItem AddToReadBtn = new WebItem("//button[@id = 'button-add-read']", "Добавление книги в прочитано");
        WebItem LoginBtn = new WebItem("//a[@class = 'button is-primary']", "Кнопка для входа в личный кабинет");
        WebItem AddToShelf = new WebItem("//button[@class='popup']", "Кнопка добавить книгу на личную полку");
        WebItem ListOfUserShelfs = new WebItem("//main[@id='listUserBookshelves']", "Список книг пользователя");
        WebItem AddToUserShelfBtn(BookShelf shelf) => new WebItem($"//p[text()='{shelf.Title}']/following-sibling:: button", "Локатор для полки с названием " + shelf.Title);
        WebItem BookNameField = new WebItem("//p[@class='book-detail-card-description-name']", "Название книги");

        public DetailBookPage AddToWillRead()
        {
            string colorBtn = AddWillReadBtn.GetAttribute("style");
            if (colorBtn == "background-color: rgb(132, 194, 92);")
            {
                AddWillReadBtn.Click();
                AddWillReadBtn.Click();
            }
            else
            {
                AddWillReadBtn.Click();
            }
;           return new DetailBookPage();
        }

        public ProfilePage ToProfilePage()
        {
            LoginBtn.Click();
            return new ProfilePage();
;       }

        public DetailBookPage AddToRead()
        {
            string colorBtn = AddToReadBtn.GetAttribute("style");

            if (colorBtn == "background-color: rgb(132, 194, 92);")
            {
                AddToReadBtn.Click();
                AddToReadBtn.Click();
            }
            else
            {
                AddToReadBtn.Click();
            }

             return new DetailBookPage();
        }

        public DetailBookPage AddToUserShelf(BookShelf shelf)
        {
            AddToShelf.Click();
            AddToUserShelfBtn(shelf).Click();
            return new DetailBookPage();
        }

        public string GetBookName ()
        {
            return BookNameField.InnerText();
        }
        
    

    }

 
}