using System;

namespace TesteBludata.Business
{
    public class BusinessException : Exception
    {
        public BusinessException() : base()
        {

        }

        public BusinessException(string mensagem) : base(mensagem)
        {

        }

        public BusinessException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {

        }
    }
}
