using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestGG.PageModels;
using TestGG.Utils;

namespace TestGG.Tests {
    [Binding, Scope(Feature = "Order")]

    public class OrderTest : Base  {
        HomePage homePage = new HomePage();
        LoginPage loginPage = new LoginPage();
        SearchPage searchPage = new SearchPage();
        ProductPage productPage = new ProductPage();
        BasketPage basketPage = new BasketPage();
        OrderPage orderPage = new OrderPage();

        [StepDefinition(@"gittigidiyor ana sayfası açılır")]
        public void OpenHomePage() {
            homePage.OpenHomePage("/");
        }

        [StepDefinition(@"popup kapatılır")]
        public void ClosePopUp() {
            homePage.ClosePopup();
        }

        [StepDefinition(@"giriş yap butonuna tıklanır")]
        public void ClickSignIn() {
            homePage.ClickSignIn();
        }

        [StepDefinition(@"kullanıcı adı alanına '(.*)' maili girilir")]
        public void SetUserName(string userName) {
            loginPage.SetUserName(userName);
        }

        [StepDefinition(@"sifre alanına '(.*)' girilir")]
        public void SetPassword(string password) {
            loginPage.SetPassword(password);
        }

        [StepDefinition(@"login butonuna basılır")]
        public void ClickLogin() {
            loginPage.ClickLogin();
        }

        [StepDefinition(@"'(.*)' araması yapılır")]
        public void SearchText(string searchWord) {
            homePage.SearchText(searchWord);
        }

        [StepDefinition(@"arama sonucçlarındaki ilk ürün tıklanır")]
        public void ClickFirstProduct() {
            searchPage.ClickFirstProduct();
        }

        [StepDefinition(@"ürün sayfasında sepete ekle butonuna basılır")]
        public void ClickAddBasket() {
            productPage.ClickAddBasket();
        }

        [StepDefinition(@"alışverişi tamamla butonuna basılır")]
        public void ClickOrder() {
            basketPage.ClickOrder();
        }

        [StepDefinition(@"sepet boşaltılır")]
        public void ClearBasket() {
            orderPage.ClickLogo();
            homePage.ClickBasket();
            basketPage.ClickDelete();
        }
        
    }
}
