using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BasisForDeveloper.NotificationPattern
{
    public class Notification
    {
        private List<String> _Notifications = new List<String>();

        public List<String> Notifications
        {
            get
            {
                ExecuteValidation();
                return _Notifications;
            }
        }

        public virtual void ExecuteValidation()
        {
        }

        /// <summary>
        /// Adds Object Notifications to a Current Instance
        /// </summary>
        public void AddNotifications(Notification ObjectNotification)
        {
            _Notifications.AddRange(ObjectNotification.Notifications);
        }

        /// <summary>
        /// Adds the list of messages to the list of notifications of the current object
        /// </summary>
        public void AddNotifications(List<String> Messages)
        {
            _Notifications.AddRange(Messages);
        }

        /// <summary>
        /// Returns True if there is no notification
        /// </summary>
        public Boolean ItsValid
        {
            get
            {
                return GetNumberOfNotifications == 0;
            }
        }

        /// <summary>
        /// Returns the number of notifications for the current object
        /// </summary>
        public int GetNumberOfNotifications
        {
            get
            {
                ExecuteValidation();
                return _Notifications.Count;
            }
        }

        /// <summary>
        /// Checks whether the object 'Object' is null, if so, it adds the message 'Message' to the list of notifications
        /// </summary>
        public void ValidIsNull(Object Object, String Message = "")
        {
            if (Object == null)
                _Notifications.Add(Message);
        }

        /// <summary>
        /// Checks whether the value 'value' is between 'begin' and 'end', if no, it adds the message 'Message' to the list of notifications
        /// </summary>
        public void ValidItsBetween(int value, int begin, int end, String Message = "")
        {
            if (value < begin || value > end)
                _Notifications.Add(Message);
        }

        /// <summary>
        /// Checks whether the 'CPF' value matches a valid CPF, if no, it adds the message 'Message' to the list of notifications
        /// </summary>
        public void ValidCPF(String CPF, String Message = "")
        {
            if (!IsCpf(CPF))
                _Notifications.Add(Message);
        }

        /// <summary>
        /// Checks whether the 'CNPJ' value matches a valid CNPJ, if no, it adds the message 'Message' to the list of notifications
        /// </summary>
        public void ValidCNPJ (String CNPJ, String Message = "")
        {
            if (!IsCnpj(CNPJ))
                _Notifications.Add(Message);
        }

        /// <summary>
        /// Checks whether the 'email' value matches a valid email, if no, it adds the message 'Message' to the list of notifications
        /// </summary>
        public void ValidEmail(String email, String Message = "")
        {
            Regex validEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            if (!validEmail.IsMatch(email))
                _Notifications.Add(Message);
        }

        //http://www.macoratti.net/11/09/c_val1.htm
        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        //http://www.macoratti.net/11/09/c_val1.htm
        public bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
