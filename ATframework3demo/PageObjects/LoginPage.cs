using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.Profile;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace atFrameWork2.PageObjects
{
    public class LoginPage
   {
        PortalInfo portalInfo;

        WebItem loginBtn = new WebItem("//a [@href='/auth/']", "Кнопка Войти в теле сайта");
        WebItem loginField = new WebItem("//input[@id='auth-login']", "Поле для ввода логина");
        WebItem pwdField = new WebItem("//input[@id='auth-pass']", "Поле для ввода пароля");
        WebItem authBtn = new WebItem("//input[@class='auth-form-btn']", "Кнопка войти на странице авторизации");


        public LoginPage(PortalInfo portal)
        {
            portalInfo = portal;
        }
        public LoginPage() 
        {

        }
        public ProfilePage Login(User admin)
        {
            DriverActions.OpenUri(portalInfo.PortalUri);

            loginBtn.Click();
            loginField.SendKeys(admin.Login);
            Thread.Sleep(1000);
            loginField.SendKeys(Keys.Enter);
            pwdField.SendKeys(admin.Password, logInputtedText: false);
            Thread.Sleep(1000);
            pwdField.SendKeys(Keys.Enter);
            return new ProfilePage();
        }
        public ProfilePage AutoLogin (User user)
        {
            loginField.SendKeys(user.Login);
            pwdField.SendKeys(user.Password);
            authBtn.Click();
            return new ProfilePage();

        }
        public bool isSendError(string expectedErrorText)
        {
            string eText = new WebItem("//div[@class = 'system-messeage-text']", "Текст ошибки на обязательные поля").InnerText();
            if (eText == expectedErrorText)
                return false;
            else
                return true;
        }
    }
}
