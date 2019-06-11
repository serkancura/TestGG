using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGG.Base;

namespace TestGG.PageModels {
    class OrderPage : BasePage {
        By btnLogo = By.CssSelector(".logo-small");

        internal void ClickLogo() {
            click(btnLogo);
        }
    }
}
