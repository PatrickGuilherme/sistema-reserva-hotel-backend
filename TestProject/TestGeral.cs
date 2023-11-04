using Application.Service;
using Application.ViewModel;
using Domain.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestFixture]
    public class TestGeral
    {
        [Test]
        public void _HotelCamposDeCadastroCorretos()
        {
            HotelViewModel hotel = new HotelViewModel
            {
                Name = "Hotel teste auto",
                Descrition = "Hotel do teste automatizado",
                CEP = "5623114",
                CNPJ = "2845263824",
                Address = "Rua almeida de jesus"
            };
            var resultadoEsperado = true;
            var retorno = hotel.VerifyInputValid();

            Assert.AreEqual(resultadoEsperado, retorno);
        }
        [Test]
        public void _HotelCamposDeCadastroInvalidos()
        {
            HotelViewModel hotel = new HotelViewModel
            {
                Name = "Hotel teste auto",
                Descrition = "Hotel do teste automatizado",
                CEP = "5623114",
                CNPJ = "2845263824",
            };
            var resultadoEsperado = false;
            var retorno = hotel.VerifyInputValid();

            Assert.AreEqual(resultadoEsperado, retorno);
        }

        [Test]
        public void _CEPValido()
        {
            HotelViewModel hotel = new HotelViewModel
            {
                Name = "Hotel teste auto",
                Descrition = "Hotel do teste automatizado",
                CEP = "40315-440",
                CNPJ = "2845263824",
            };
            var resultadoEsperado = true;
            var retorno = hotel.VerifyCEPValid();
            Assert.AreEqual(resultadoEsperado, retorno);
        }

        [Test]
        public void _CEPInValido()
        {
            HotelViewModel hotel = new HotelViewModel
            {
                Name = "Hotel teste auto",
                Descrition = "Hotel do teste automatizado",
                CEP = "4031599440",
                CNPJ = "2845263824",
            };
            var resultadoEsperado = false;
            var retorno = hotel.VerifyCEPValid();
            Assert.AreEqual(resultadoEsperado, retorno);
        }

        [Test]
        public void _CNPJValido()
        {
            HotelViewModel hotel = new HotelViewModel
            {
                Name = "Hotel teste auto",
                Descrition = "Hotel do teste automatizado",
                CEP = "4031599440",
                CNPJ = "03.795.071/0001-16"
            };
            var resultadoEsperado = true;
            var retorno = hotel.VerifyCNPJ();
            Assert.AreEqual(resultadoEsperado, retorno);
        }

        [Test]
        public void _CNPJInValido()
        {
            HotelViewModel hotel = new HotelViewModel
            {
                Name = "Hotel teste auto",
                Descrition = "Hotel do teste automatizado",
                CEP = "4031599440",
                CNPJ = "12y79i",
            };
            var resultadoEsperado = false;
            var retorno = hotel.VerifyCNPJ();
            Assert.AreEqual(resultadoEsperado, retorno);
        }
     

        [Test]
        public void _UserAuthorizationSucesso()
        {
            UserRepository userrep = new UserRepository();
            var resultData = userrep.LoginTest("u1@gmail.com", "123456");
            Assert.AreEqual(true, resultData);
        }

        [Test]
        public void _UserAuthorizationErro()
        {
            UserRepository userrep = new UserRepository();
            var resultData = userrep.LoginTest("u1@gmail.com", "senha errada");
            Assert.AreEqual(false, resultData);
        }
    }
}
