using BasisForDeveloper.NotificationPattern;
using System;
using System.Linq;
using Xunit;

namespace TestOfBasisForDeveloper
{
    public class TesteNotification
    {
        [Fact]
        public void RecebendoReferenciaNula()
        {
            Notification Test = new Notification();
            Notification err = null;
            Test.AddNotifications(err);
            Assert.Equal(1, Test.GetNumberOfNotifications);
        }

        [Fact]
        public void AdicionaNotificacaoManual()
        {
            Notification Test = new Notification();
            Test.AddNotifications("oi");
            Assert.Equal("oi", Test.Notifications.FirstOrDefault());
            Assert.Equal(1, Test.GetNumberOfNotifications);
        }

        [Fact]
        public void ValidaEmail()
        {
            Notification Test = new Notification();
            String ErroMessagem = "Email Invalido";
            Test.ValidEmail("lucassalvino1@gmail.com", ErroMessagem);
            Assert.Equal(0, Test.GetNumberOfNotifications);
            Test.ValidEmail("ADJAHSDJHALSJKDHALSKJDHA");
            Assert.Equal(1, Test.GetNumberOfNotifications);
            Assert.Equal(ErroMessagem, Test.Notifications.First());
        }
    }
}
