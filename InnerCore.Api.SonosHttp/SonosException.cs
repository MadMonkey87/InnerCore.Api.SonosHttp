using System;

namespace InnerCore.Api.SonosHttp
{
    public abstract class SonosException : Exception
    {
        public SonosException(string message) : base(message)
        {

        }
    }

    public class CommandFailedException : SonosException
    {
        public CommandFailedException(string message) : base(message)
        {

        }
    }
}
