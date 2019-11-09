using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto.Teste._01.Models;
using Projeto.Teste._01.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste._01.Tests
{
    [TestClass]
    public class CriarContaDeClienteTest
    {
        [TestMethod]
        public void CriacaoDeContaDeClienteComSucesso()
        {
            try
            {
                var model = new CriarContaDeClienteModel
                {
                    Nome = "Luana",
                    Sobrenome = "Teixeira",
                    Email = $"lteixeira{new Random().Next(1,999999)}@muxi.com.br",
                    Senha = "123456"
                };

                using (var steps = new CriarContaDeClienteSteps(model))
                {
                    steps.AcessarPaginaDeCadastroDeConta();
                    steps.PreencherCampoNome();
                    steps.PreencherCampoSobrenome();
                    steps.PreencherCampoEmail();
                    steps.PreencherEConfirmarSenha();
                    steps.RealizarCadastro();

                    var resultadoObtido = steps.ObterMensagem();
                    var resultadoEsperado = "Obrigado por se registrar com LOJA EXEMPLO de Livros";

                    Assert.AreEqual(resultadoEsperado, resultadoObtido);
                }     
            }
            catch (Exception e)
            {
                Assert.Fail("Falha ao executar o teste: " + e.Message);
            }
        }
    }
}
