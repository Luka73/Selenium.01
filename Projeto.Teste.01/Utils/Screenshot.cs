using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste._01.Utils
{
    public class Screenshot
    {
        public static void Create(IWebDriver driver)
        {
            var take = driver as ITakesScreenshot;
        }
    }
}
