using System;
using System.Runtime.Serialization;
using System.Text;

namespace Utility.Exceptions
{
    public class TvShowException: Exception
    {

        public TvShowException() {
            
        }

        public TvShowException(string message) {
            LogAtmira.Instance.logger.Error(message);
        }

        public TvShowException(string message, Exception innerException) {
            LogAtmira.Instance.logger.Error(message + innerException.StackTrace);
        }

        protected TvShowException(SerializationInfo info, StreamingContext context) { 

        }

    }
}
