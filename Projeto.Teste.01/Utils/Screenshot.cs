﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste._01.Utils
{
    public class Screenshot
    {
        public static void Create(IWebDriver driver, string fileName)
        {
            var take = driver as ITakesScreenshot;
            var foto = take.GetScreenshot();

            foto.SaveAsFile("c:\\temp\\" + fileName, ScreenshotImageFormat.Png);
        }
    }
}
