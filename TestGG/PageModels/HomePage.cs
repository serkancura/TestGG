using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGG.Base;

namespace TestGG.PageModels {
    class HomePage : BasePage {

        By popupClose = By.Id("gg-subscribe-close-button");
        By imgLogo = By.ClassName("header-gg-logo robot-header-logoContainer-logo");
        By txtProfileName = By.ClassName("profile-name ");
        By btnSignIn = By.Id("SignIn");
        By txtSearch = By.Id("search_word");
        By btnSearch = By.Id("header-search-find-link");
        By btnBasket = By.ClassName("basket-icon-container");

        internal void ClickSignIn() {
            mouseOver(txtProfileName);
            click(btnSignIn);
        }

        internal void OpenHomePage(string url) {
            visit(url);
            isDisplayed(imgLogo);          
        }

        internal void ClosePopup() {
            waitElement(popupClose);
            click(popupClose);
        }

        internal void SearchText(string searchWord) {
            type(searchWord, txtSearch);
            click(btnSearch);
        }

        internal void ClickBasket() {
            click(btnBasket);
        }
    }
}
