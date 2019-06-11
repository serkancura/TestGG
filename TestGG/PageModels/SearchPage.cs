using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGG.Base;

namespace TestGG.PageModels {
    class SearchPage : BasePage {

        By firstProduct = By.XPath("//li[@product-index='1']");

        internal void ClickFirstProduct() {
            click(firstProduct);
        }

    }
}
