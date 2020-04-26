using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
