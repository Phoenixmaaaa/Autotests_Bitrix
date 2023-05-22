using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.BookShelfCreationPage;
using ATframework3demo.PageObjects.Profile;
using System.Text;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;
using System;

namespace ATframework3demo.TestCases
{
    public class TestCases : CaseCollectionBuilder
    {
        Book TestBookToWillRead = new Book("Рассвет");
        Book TestBookToRead = new Book("Сумерки");
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
            {
               new TestCase("Регистрация нового пользователя",mainPage =>CreateNewLitLabUser(mainPage)),
               new TestCase("Добавление книги в Буду читать",mainPage => AddToWillRead(mainPage,TestBookToWillRead)),
               new TestCase("Добавление книги в Прочитано", mainPage => AddToRead(mainPage,TestBookToRead)),
               new TestCase("Добавление книги в пользотвательские полки",mainPage => AddToUserShelf(mainPage)),
               new TestCase("Добавление новой книги",mainPage => AddBookToLitLab(mainPage))

            };
        }
        /* Описание тест кейса на регистрацию нового пользователя
         * 1. Создать 5 пользователей: 
         *      1.1 с пустыми данными, 
         *      1.2 с данными большей длины, чем возможно
         *      1.3 с данными меньшей длины, чем возможно
         *      1.4 с логином, который уже используется
         *      1.5 Юзера с уникальным данными,допустимые
         * 2. Регистрация пользователя с пустыми данными
         *      2.1. Попытка зарегестрировать
         *      2.2  Проверить ошибку
         * 3. Регистрация пользователя с данными, которые меньше чем допустимые
         *      3.1. Попытка зарегестрировать
         *      3.2  Проверить ошибку
         * 4. Регистрация пользователя с данными, которые больше чем допустимые
         *      4.1. Попытка зарегестрировать
         *      4.2  Проверить ошибку
         * 5. Регистрация пользователя с логином, которые уже используется
         *      5.1. Попытка зарегестрировать
         *      5.2  Проверить ошибку
         * 6. Регистрация пользователя с корректными данными
         * 7. Авторизоваться за созданного пользователя
         * 8. Проверить логин
         */
        private void CreateNewLitLabUser (ProfilePage mainPage)
        {
            string user = "login" + DateTime.Now.Ticks;
            string userEmpty = "                  ";
            string userMin = "min";
            string userMax = new StringBuilder().Insert(0, user, 20).ToString();
            string userInUse = "admin";

            var emptyUser = new User (userEmpty, userEmpty, userEmpty);
            var maxUser = new User (userMax, userMax, userMax);
            var minUser = new User (userMin, userMin, userMin);
            var inUseUser = new User (userInUse, userInUse, user);
            var correctUser = new User (user, user, user);

            var registrationFormEmpty = mainPage.
                 OpenRegistrationForm().
                 FillLogin(emptyUser.Login).
                 FillNick(emptyUser.Nick).
                 FillPassword(emptyUser.Password).
                 SignUp();

            if (registrationFormEmpty.isSendError("Обязательные поля не были заполнены. Попробуйте ещё раз."))
            {
                Log.Error("Нет сообщения об ошибке при регистрации пользователя с пустыми данными");
                return;
            }

           var registrationFormMin = new RegistrationForm().
                 FillLogin(minUser.Login).
                 FillNick(minUser.Nick).
                 FillPassword(minUser.Password).
                 SignUp();

            if (registrationFormMin.isSendError("Введено значение недостаточной длины."))
            {
                Log.Error("Нет сообщения об ошибке при регистрации пользователя с данными длины меньше чем допустимая");
                return;
            }

           var registrationFormMax = new RegistrationForm().
                FillLogin(maxUser.Login).
                FillNick(maxUser.Nick).
                FillPassword(maxUser.Password).
                SignUp();

            if (registrationFormMax.isSendError("Введите значение меньшей длины."))
            {
                Log.Error("Нет сообщения об ошибке при регистрации пользователя с данными длины больше чем допустипая");
                return;
            }

            var registrationFormInUse = new RegistrationForm().
                FillLogin(inUseUser.Login).
                FillNick(inUseUser.Nick).
                FillPassword(correctUser.Password).
                SignUp();

            if (registrationFormInUse.isSendError("Логин занят."))
            {
                Log.Error("Нет сообщения об ошибке при регистрации пользователя c логином, который уже занят");
                return;
            }

            var registrationForm = new RegistrationForm().
               FillLogin(correctUser.Login).
               FillNick(correctUser.Nick).
               FillPassword(correctUser.Password).
               SignUp();
            var profile = registrationForm.AutoLogin(correctUser);

            if (!profile.IsCorrectUserName (correctUser))
            {
                Log.Error("Данные логина зарегестрированного пользотвателя не совпадают с данными пользователя, под которым мы вошли");
            }
        }

        /* Действие над книгой: добавление книги в "Буду читать"
         * 1. Открыть страницу с книгами
         * 2. В поиске найти книгу "Тестовая книга"
         * 3. Нажать на кнопку "Буду читать"
         * 3. Нажать "изменить" рядом с полкой "Буду читать"
         * 4. Проверка нашлась ли книга на полке
         */

        private void AddToWillRead (ProfilePage mainPage, Book book)
        {
           var shelf = new BookShelf("Буду читать");

            var bookPage = mainPage.
                 OpenBookPage().
                 SearchBook(book);

           if (!bookPage.isCorrectName(book))
           {
                Log.Error("Книга с названием не найдена");
                return;
           }
            var bookRedactPage = bookPage.
                 ToFirstBookDetailPage().
                 AddToWillRead().
                 ToProfilePage().
                 OpenRedactionFCS(shelf);

           if(!bookRedactPage.IsBookOnShelf(book))
           {
                Log.Error("Книга не была добавлена на полку"+shelf);

           }
                 
        }

        /* Действие над книгой: добавление книги в "Прочитано"
         * 1. Открыть страницу с книгами
         * 2. В поиске найти книгу "Тестовая книга"
         * 3. Нажать на кнопку "Прочитано"
         * 3. Нажать "изменить" рядом с полкой "Прочитано"
         * 4. Проверка нашлась ли книга на полке
         */

        private void AddToRead(ProfilePage mainPage, Book book)
        {
            var shelf = new BookShelf("Прочитано");

            var bookPage = mainPage.
                 OpenBookPage().
                 SearchBook(book);

            if (!bookPage.isCorrectName(book))
            {
                Log.Error("Книга с названием не найдена");
                return;
            }
            var bookRedactPage = bookPage.
                 ToFirstBookDetailPage().
                 AddToRead().
                 ToProfilePage().
                 OpenRedactionFCS(shelf);

            if (!bookRedactPage.IsBookOnShelf(book))
            {
                Log.Error("Книга не была добавлена на полку"+ shelf);
            }
        }

        /* Действие над книгой: добавление книги на пользотвательскую полку
      * 1. Открыть страницу с ЛК
      * 2. Создать полку
      * 3. Открыть страницу с книгами
      * 4. Добавить первую книгу со страницы (с наивысшем рейтингом) в полку, созданную в пункте 2
      * 5. Нажать "изменить" рядом с полкой, созданной в пункте 2 в личном кабинете
      * 6. Проверка нашлась ли книга на полке
      */
        private void AddToUserShelf(ProfilePage mainPage)
        {
            var title = "Shelf" + DateTime.Now.Ticks;
            var myShelf = new BookShelf(title);
            var bookDetailPage = mainPage.
                OpenPersonalAccount().
                OpenShelfCreationPage().
                CreateShelf(myShelf).
                OpenBookPage().
                ToFirstBookDetailPage().
                AddToUserShelf(myShelf);
            var myBook = new Book(bookDetailPage.GetBookName());

            var redactBookPage = bookDetailPage.
                ToProfilePage().
                OpenLastProfilePage().
                OpenRedactionFCS(myShelf);

            if (!redactBookPage.IsBookOnShelf(myBook))
            {
                Log.Error("Книга не была добавлена на полку" + myShelf);
            }


        }

        /* Добавления новой книги в БД
         * 1. Открыть старницу с ЛК
         * 2. Перейти на форму добавления новой книги
         * 3. Заполнить поле Название пробелами и нажать "Сохранить"
         * 4. Проверить появление ошибки
         * 5. Заполнить поле Автор слишком длинной строкой
         * 6. Проверить наличие ошибки
         * 7. Заполнить поля название, автор строками, соответствующими требованиям
         * 8. Проверить, что мы перенаправлены в ЛК
         */

        private void AddBookToLitLab (ProfilePage mainPage)
        {
            Book correctBook = new Book("B_" + DateTime.Now.Ticks);
            Book emptyBook = new Book("     ");
            Book maxBook = new Book();
            maxBook.Author = new StringBuilder().Insert(0, correctBook.Author, 100).ToString();
            maxBook.Title = "title";

            var addEmptyBook = mainPage.
                OpenPersonalAccount().
                OpenAddBookForm().
                AddNewBook(emptyBook);

            if(addEmptyBook.IsSendError("Обязательные поля не были заполнены. Попробуйте ещё раз."))
            {
                Log.Error("Нет ожидаемого системного сообщения при добавлении книги, чье название - это пробелы");
                return;
            }

            var addMaxBook = new FormToAddBook().
                AddNewBook(maxBook);

            if(addMaxBook.IsSendError("Введите значение меньшей длины."))
            {
                Log.Error("Нет ожидаемого системного сообщения при добавлении книги, чье описание - это очень длинная строка, не соответствующая требованиям");
                return;
            }

            var addCorrectBook = new FormToAddBook().
                AddNewBook(correctBook);

            if(!addCorrectBook.isPersonalAccount())
            {
                Log.Error("После сохранения полки с корректными данными мы не были перенаправлены в ЛК. Ошибка");
                return;
            }


        }
    }
}
