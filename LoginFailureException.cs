namespace Planbox.Net
{
    using System;

    public class LoginFailureException : Exception
    {
        public LoginFailureException(string error)
            : base(error)
        {
        }
    }
}
