using BasisForDeveloper.NotificationPattern;
using System;

namespace TestBasisForDeveloper
{
    public class main
    {
        public static void Main(string[] args)
        {
            Notification Test = new Notification();
            String ErroMessagem = "Email Invalido";
            Test.ValidEmail("lucassalvino1@gmail.com", ErroMessagem);
            Console.ReadKey();
        }
    }
}
