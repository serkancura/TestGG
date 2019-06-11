using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGG.Base;

namespace TestGG.PageModels {
    class BasketPage : BasePage {
        By btnOrder = By.CssSelector(".btn-pay");
        By btnDelete = By.CssSelector(".btn-delete");

        internal void ClickOrder() {
            click(btnOrder);
        }

        internal void ClickDelete() {
            click(btnDelete);
        }
    }
}
