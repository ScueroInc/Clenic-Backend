using System;

namespace MyE.Business.Component.Helpers
{
    public class ExceptionHelper : Exception
    {
        public ExceptionHelper(string message) : base(message)
        {
        }

        public ExceptionHelper(Exception ex) : this(ex.Message)
        {
        }
    }
}