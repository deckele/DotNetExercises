using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    [Serializable]
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() { }
        public InsufficientFundsException(string message) : base(message) { }
        public InsufficientFundsException(string message, Exception inner) : base(message, inner) { }
        protected InsufficientFundsException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
