using System;

namespace Qontak.Crm
{
    public class QontakCrmException : Exception
    {
        public QontakCrmException()
        {
        }

        public QontakCrmException(string message) : base(message)
        {
        }

        public QontakCrmException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
