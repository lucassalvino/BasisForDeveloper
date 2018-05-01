using System;

namespace BasisForDeveloper.CustomExceptionDefinition
{
    public class CustomException : Exception
    {
        public String ErrorCode { get; set; }

        public CustomException() { }

        public CustomException(String Message)
            :base(Message){ }

        public CustomException(String Message, Exception InnerException)
            : base(Message, InnerException) { }

        public CustomException(String Message, String ErrorCode)
            :base(Message)
        {
            Initialise(ErrorCode);
        }

        public CustomException(String Message, Exception InnerException, String ErrorCode)
            :base(Message, InnerException)
        {
            Initialise(ErrorCode);
        }

        private void Initialise(String ErrorCode)
        {
            this.ErrorCode = ErrorCode;
        }
    }
}
