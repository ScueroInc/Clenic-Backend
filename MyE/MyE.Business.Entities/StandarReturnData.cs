using System;
using System.Collections.Generic;
using System.Text;

namespace MyE.Business.Entities
{
    public class StandarReturnData : StandarReturn
    {

        public object result { get; set; }
        public StandarReturnData() { }
        public StandarReturnData(bool error, string message, object result)
        {           
            this.error = error;
            this.message = message;
            this.result = result;
        }
        public StandarReturnData(string estado, object result = null)
        {
            if (estado == "error")
            {                
                this.error = true;
                this.message = "Ocurrio un error";
                this.result = result;
            }
            else if (estado == "ok")
            {               
                this.error = false;
                this.message = "";
                this.result = result;
            }
        }
    }
}
