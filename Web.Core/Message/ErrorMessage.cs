using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Core.Message
{
   public class ErrorMessageObj
    {
        public ErrorMessageCode Code { get; set; }
        public string Message { get; set; }
    }
     public class ErrorMessage
    {

         public List<ErrorMessageObj> Errors { get; set; }
        public  ErrorMessage()
        {
            Errors = new List<ErrorMessageObj>();
        }

        public void AddErrors(ErrorMessageCode code,string message)
        {
            Errors.Add(new ErrorMessageObj() { Code = code, Message = message });
        }
    }
    
}
