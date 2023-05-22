using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.BookShelfCreationPage;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Profile
{
    public class ProfilePage
    {
        WebItem CreateNewShelfBtn = new WebItem("//a [@href='/create/bookshelf/']", "Кнопка создания новой полки");
        WebItem LastProfilePageBtn = new WebItem("//li [@class=''][last()]/child::a[@href]", "Кнопка открытия последней страницы с полками в профиле");
        WebItem CreatedShelfRedactBtn(string shelfName) => new WebItem($"//div[@class='user-bookshelf-description']//a[text()=" +
            $"'{shelfName}']//following::div[@class='user-bookshelf-buttons']//a",
            "Кнопка изменить к созданной полке");

        WebItem LogoutBtn = new WebItem("//a [@href='/logout/']", "Кнопка выйти");
        WebItem SignUpBtn = new WebItem("//a [@href='/register/']", "Кнопка зарегестрироваться");
        WebItem loginBtn = new WebItem("//a[@class = 'button is-primary']", "Кнопка для входа в личный кабинет");
        WebItem BookPageBtn = new WebItem("//*[@id=\"navbarBasicExample\"]/a[2]", "Кнопка для перехода на страницу книг");
        WebItem AddNewBookBtn = new WebItem("//a[@href='/create/book/']", "Кнопка для перехода на страницу добавления новой книги в БД");
        WebItem SystemMesseageAddNewBook = new WebItem("//main[@class='system-messeage']", "Ошибка при добавления новой книги");

        public BookshelfCreationPage OpenShelfCreationPage()
        {
            CreateNewShelfBtn.Click();
            return new BookshelfCreationPage();
        }

        public ProfilePage OpenLastProfilePage()
        {
            try
            {
                LastProfilePageBtn.Click();
            }
            catch { }
            return this;
             
        }

        public BookshelfRedactPage OpenRedactionFCS(BookShelf shelf)
        {
            CreatedShelfRedactBtn(shelf.Title).Click();
            return new BookshelfRedactPage();
        }

        public RegistrationForm OpenRegistrationForm()
        {
            LogoutBtn.Click();
            SignUpBtn.Click();
            return new RegistrationForm();
        }

        public BooksPage OpenBookPage()
        {
            BookPageBtn.Click();
            return new BooksPage();
        }

        public bool IsCorrectUserName(User user)
        {
            if (user.Login == loginBtn.InnerText())
                return true;
            else
                return false;
        }

        public ProfilePage OpenPersonalAccount()
        {
            loginBtn.Click();
            return new ProfilePage();
        }

        public FormToAddBook OpenAddBookForm()
        {
            AddNewBookBtn.Click();
            return new FormToAddBook();
        }

        public bool IsSendError(string expectedErrorText)
        {
            string eText = SystemMesseageAddNewBook.InnerText();
            if (eText == expectedErrorText)
                return false;
            else
                return true;
        }

        public bool isPersonalAccount()
        {
            try
            {
                CreateNewShelfBtn.Click();
                return true;
            }
            catch { }
            return false;
        }

    }
}
