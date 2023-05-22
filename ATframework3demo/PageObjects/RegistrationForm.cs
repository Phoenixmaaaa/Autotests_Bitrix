using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class RegistrationForm
    {
        WebItem LoginField = new WebItem("//input[@name='login']", "Поле ввода логина");
        WebItem UserNameField = new WebItem("//input[@name='username']", "Поле ввода ника");
        WebItem PasswordField = new WebItem("//input[@name='pass']", "Поле ввода пароля");
        WebItem SignUpBTN = new WebItem("//input[@type='submit']", "Кнопка регистрации");
        public RegistrationForm FillLogin(string login)
        {
            LoginField.SendKeys(login);
            return this;
        }

        public RegistrationForm FillNick(string nick)
        {
            UserNameField.SendKeys(nick);
            return this;
        }

        public RegistrationForm FillPassword(string password)
        {
            PasswordField.SendKeys(password);
            return this;
        }

        public LoginPage SignUp()
        {
            SignUpBTN.Click();
            var myLoginPage = new LoginPage();
            return myLoginPage;
        }
    }
}
