using System;
using System.IO;
using BasisForDeveloper.ConfigurationDefinition;
using BasisForDeveloper.CustomExceptionDefinition;

namespace BasisForDeveloper.Logs
{
    public class TreatLogs
    {
        /// <summary>
        /// Retorna o nome do Arquivo onde o log atual será salvo
        /// </summary>
        /// <remarks>
        /// É necessário que o parâmetro 'FolderLog' de InstanceConfiguration esteja definido em 'Config/Config.json'
        /// </remarks>
        private static String GetNameLogFile()
        {
            String Retur = $"{InstanceConfiguration<ConfigurationFile>.Config.FolderLog}/{DateTime.Now.Date.ToShortDateString()}.log";
            return Retur;
        }

        /// <summary>
        /// Retorna o nome do arquivo para salvar o registro da exceção atual, o nome conterá a data e horário do salvamento.
        /// </summary>
        /// <remarks>
        /// É necessário que o Parâmetro 'FolderLog' de InstanceConfiguration esteja definido em 'Config/Config.json'
        /// </remarks>
        private static String GetNameExceptionFile()
        {
            String Retur = $"{InstanceConfiguration<ConfigurationFile>.Config.FolderLog}/{DateTime.Now.ToShortDateString()}_{DateTime.Now.ToShortTimeString()}.Exception";
            return Retur;
        }

        private static void _AddLog(String Message, String NameFile)
        {
            if (InstanceConfiguration<ConfigurationFile>.Config.ShowLog || InstanceConfiguration<ConfigurationFile>.Config.SaveLog)
            {
                Message = $"[{DateTime.Now}] {Message}";
                if (InstanceConfiguration<ConfigurationFile>.Config.ShowLog)
                    Console.WriteLine(Message);
                if (InstanceConfiguration<ConfigurationFile>.Config.SaveLog)
                {
                    StreamWriter file = File.AppendText(NameFile);
                    file.WriteLine(Message);
                    file.Close();
                }
            }
        }

        private static String _GetLogException(Exception Error)
        {
            if (Error == null) return String.Empty;
            String Retor = "";
            if(Error.GetType() == typeof(CustomException))
            {
                CustomException ErrorCustom = Error as CustomException;
                Retor = $"Codigo: [{ErrorCustom.ErrorCode}]\n";
            }
            Retor += $"Message? [{Error.Message}]\n StackTrace: [{Error.StackTrace}]";
            if(Error.InnerException != null)
            {
                return ($"{Retor}\n\n {_GetLogException(Error.InnerException)}");
            }
            return Retor;
        }

        /// <summary>
        /// Adiciona um novo arquivo a pasta definida em 'FolderLog' em 'Config/Config.json'
        /// Cada Exceção é salva em um arquivo separado
        /// </summary>
        /// <param name="Error"></param>
        public static void AddExceptionFile(Exception Error)
        {
            String NameFile = GetNameExceptionFile();
            String Message = _GetLogException(Error);
            _AddLog(Message, NameFile);
        }

        /// <summary>
        /// Adiciona um novo registro ao arquivo de logs. Um arquivo de logs é criado para cada dia, na pasta definida em 'FolderLog' em 'Config/Config.json'
        /// </summary>
        /// <param name="Message"></param>
        public static void AddLog(String Message)
        {
            _AddLog(Message, GetNameLogFile());
        }
    }
}
