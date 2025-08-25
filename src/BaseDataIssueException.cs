using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FixGunpowderWeight
{
    internal class BaseDataIssueException : Exception
    {
        public BaseDataIssueException()
        {
        }

        public BaseDataIssueException(string message) : base(message)
        {
        }

        public BaseDataIssueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BaseDataIssueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
