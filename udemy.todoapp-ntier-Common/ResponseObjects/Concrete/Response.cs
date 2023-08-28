using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.todoapp_ntier_Common.ResponseObjects.Abstract;

namespace udemy.todoapp_ntier_Common.ResponseObjects.Concrete
{
    public class Response : IResponse
    {
        public Response(ResponseType responseType)
        {
            ResponseType = responseType;            
        }

        public Response(ResponseType responseType, string message)
        {
            ResponseType = responseType;
            Message = message; 
        }

        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }

    public enum ResponseType
    {
        Success,
        ValidationError,
        NotFound
    }
}
