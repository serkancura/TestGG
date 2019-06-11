using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGG.Base;

namespace TestGG.PageModels {
    class ProductPage : BasePage {

        By addBasket = By.Id("add-to-basket");

        internal void ClickAddBasket() {
            click(addBasket);
        }
    }
}
