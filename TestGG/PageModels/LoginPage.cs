using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGG.Base;

namespace TestGG.PageModels {
    class LoginPage : BasePage{

        By txtUserName = By.Id("L-UserNameField");
        By txtPassword = By.Id("L-PasswordField");
        By btnLogin = By.Id("gg-login-enter");

        internal void SetUserName(string userName) {
            type(userName, txtUserName);
        }

        internal void SetPassword(string password) {
            type(password, txtPassword);
        }

        internal void ClickLogin() {
            click(btnLogin);
        }
    }
}
