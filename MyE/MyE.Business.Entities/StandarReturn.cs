using System;
using System.Collections.Generic;
using System.Text;

namespace MyE.Business.Entities
{
    public class StandarReturn
    {      
        public bool error { get; set; }
        public string message { get; set; }
        public StandarReturn() { }
        public StandarReturn(bool error, string message)
        {       
            this.error = error;
            this.message = message;
        }
        public StandarReturn(string estado)
        {
            if (estado == "error")
            {               
                this.error = true;
                this.message = "Ocurrio un error";
            }
            else if (estado == "ok")
            {               
                this.error = false;
                this.message = "";
            }
        }

    }
}
