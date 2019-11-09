using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Projeto.Teste._01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste._01.Steps
{
    public class CriarContaDeClienteSteps : IDisposable
    {
        private readonly CriarContaDeClienteModel model;
        private readonly IWebDriver webDriver;

        public CriarContaDeClienteSteps(CriarContaDeClienteModel model)
        {
            this.model = model;
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }

        public void AcessarPaginaDeCadastroDeConta()
        {
            webDriver.Navigate().GoToUrl("https://lojaexemplod.lojablindada.com/customer/account/create/");
        }

        public void PreencherCampoNome()
        {
            var element = webDriver.FindElement(By.CssSelector("#firstname"));
            element.Clear();
            element.SendKeys(model.Nome);
        }

        public void PreencherCampoSobrenome()
        {
            var element = webDriver.FindElement(By.CssSelector("#lastname"));
            element.Clear();
            element.SendKeys(model.Sobrenome);
        }

        public void PreencherCampoEmail()
        {
            var element = webDriver.FindElement(By.CssSelector("#email_address"));
            element.Clear();
            element.SendKeys(model.Email);
        }

        public void PreencherEConfirmarSenha()
        {
            var element = webDriver.FindElement(By.CssSelector("#password"));
            element.Clear();
            element.SendKeys(model.Senha);

            element = webDriver.FindElement(By.CssSelector("#confirmation"));
            element.Clear();
            element.SendKeys(model.Senha);
        }

        public void RealizarCadastro()
        {
            var element = webDriver.FindElement(By.CssSelector("#form-validate > div.buttons-set > button"));

            if (element.Enabled)
                element.Click();
        }

        public string ObterMensagem()
        {
            var element = webDriver.FindElement(By.CssSelector("body > div > div > div.main-container.col2-left-layout > div > div.col-main > div > div > ul > li > ul > li > span"));
            return element.Text;
        }
        
        //Fechar o navegador
        public void Dispose()
        {
            webDriver.Close();
            webDriver.Dispose();
        }
    }
}
