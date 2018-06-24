using BasisForDeveloper.NotificationPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class TestOfNotification
    {
        [TestMethod]
        public void RecebendoReferenciaNula()
        {
            Notification Test = new Notification();
            Notification err = null;
            Test.AddNotifications(err);
            Assert.AreEqual(1, Test.GetNumberOfNotifications);
        }

        [TestMethod]
        public void AdicionaNotificacaoManual()
        {
            Notification Test = new Notification();
            Test.AddNotifications("oi");
            Assert.AreEqual("oi", Test.Notifications.FirstOrDefault());
            Assert.AreEqual(1, Test.GetNumberOfNotifications);
        }

        [TestMethod]
        public void ValidaEmail()
        {
            Notification Test = new Notification();
            String ErroMessagem = "Email Invalido";
            Test.ValidEmail("lucassalvino1@gmail.com", ErroMessagem);
            Assert.AreEqual(0, Test.GetNumberOfNotifications);
            Test.ValidEmail("ADJAHSDJHALSJKDHALSKJDHA", ErroMessagem);
            Assert.AreEqual(1, Test.GetNumberOfNotifications);
            Assert.AreEqual(ErroMessagem, Test.Notifications.First());
        }

        [TestMethod]
        public void ValidaTestIntervaloInteiro()
        {
            Notification Test = new Notification();
            String ErroMessagem = "Numero fora de intervalo";
            Test.ValidItsBetween(5, 0, 5, ErroMessagem);
            Assert.AreEqual(0, Test.GetNumberOfNotifications);
            Test.ValidItsBetween(-5, -5, 5, ErroMessagem);
            Assert.AreEqual(0, Test.GetNumberOfNotifications);
            Test.ValidItsBetween(0, -5, 5, ErroMessagem);
            Assert.AreEqual(0, Test.GetNumberOfNotifications);
            Test.ValidItsBetween(0.5 , -5, 5, ErroMessagem);
            Assert.AreEqual(0, Test.GetNumberOfNotifications);
            Test.ValidItsBetween(6, -5, 5, ErroMessagem);
            Assert.AreEqual(1, Test.GetNumberOfNotifications);
            Assert.AreEqual(ErroMessagem, Test.Notifications.First());
        }

        [TestMethod]
        public void ValidaAdicaoNotificacaoDeOutraNotificacao()
        {
            Notification Test = new Notification();
            String ErroMessagem = "Numero fora de intervalo";
            Test.ValidItsBetween(5, 0, 5, ErroMessagem);
            Notification Test2 = new Notification();
            Test2.AddNotifications(Test);
            Assert.AreEqual(0, Test2.GetNumberOfNotifications);
            Test.ValidItsBetween(6, -5, 5, ErroMessagem);
            Test2.AddNotifications(Test);
            Assert.AreEqual(1, Test2.GetNumberOfNotifications);
            Assert.AreEqual(false, Test2.ItsValid);
            Assert.AreEqual(false, Test.ItsValid);
            Test2.AddNotifications("teste");
            Assert.AreEqual(2, Test2.GetNumberOfNotifications);
        }

        [TestMethod]
        public void ValidaCPF()
        {
            Notification Test = new Notification();
            String ErroMessagem = "CPF invalido";
            Test.ValidCPF("05744321160", ErroMessagem);
            Assert.AreEqual(0, Test.GetNumberOfNotifications);
            Test.ValidCPF("85285017017", ErroMessagem);
            Assert.AreEqual(0, Test.GetNumberOfNotifications);
            Test.ValidCPF("37835748037", ErroMessagem);
            Assert.AreEqual(0, Test.GetNumberOfNotifications);
            Assert.AreEqual(true, Test.ItsValid);
            Test.ValidCPF("05744321161", ErroMessagem);
            Assert.AreEqual(1, Test.GetNumberOfNotifications);
            Test.ValidCPF("85285017017", ErroMessagem);
            Assert.AreEqual(1, Test.GetNumberOfNotifications);
            Test.ValidCPF("37835748038", ErroMessagem);
            Assert.AreEqual(2, Test.GetNumberOfNotifications);
            Assert.AreEqual(false, Test.ItsValid);
        }

        [TestMethod]
        public void ValidaCNPJ()
        {
            Notification Test = new Notification();
            String ErroMessage = "CNPJ invalido";
            Test.ValidCNPJ("88108643000102", ErroMessage);
            Assert.AreEqual(0, Test.GetNumberOfNotifications);
            Test.ValidCNPJ("23357702000122", ErroMessage);
            Assert.AreEqual(0, Test.GetNumberOfNotifications);
            Test.ValidCNPJ("14689078000170", ErroMessage);
            Assert.AreEqual(0, Test.GetNumberOfNotifications);
            Assert.AreEqual(true, Test.ItsValid);
            Test.ValidCNPJ("88108643000104", ErroMessage);
            Assert.AreEqual(1, Test.GetNumberOfNotifications);
            Test.ValidCNPJ("23357702000122", ErroMessage);
            Assert.AreEqual(1, Test.GetNumberOfNotifications);
            Test.ValidCNPJ("146890780021170", ErroMessage);
            Assert.AreEqual(2, Test.GetNumberOfNotifications);
            Assert.AreEqual(false, Test.ItsValid);
        }
    }
}
